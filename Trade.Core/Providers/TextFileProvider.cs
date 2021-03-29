using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using Trade.Core.Entity;
using Trade.Core.Interfaces;
using Trade.Core.Validators;
using Trade.Notification;
using Trade.Notification.Notifications;
using Trade.Notification.Phrases;

namespace Trade.Core.Providers
{
    public class TextFileProvider : BaseService, IDataProvider
    {
        
        public TextFileProvider() : base(new Notifier())
        {
        }

        string IDataProvider.GetSource()
        {
            string path = ConfigurationManager.AppSettings["filePath"];
            DirectoryInfo o_Dir = new DirectoryInfo(path);
            FileInfo[] files = o_Dir.GetFiles("*.txt");
            if (files.Length > 0)
            {
                string file = files[0].Name;
                return path + "\\" + file;
            }
            return "";
        }

        IPortfolio IDataProvider.GetAndValidatePotfolio(string source)
        {
            string[] lines = File.ReadAllLines(source);

            IList<ITrade> trades = new List<ITrade>();

            int numberOfTrades;

            if (!int.TryParse(lines[1], out numberOfTrades))
            {
                Notifier("Number of trades in the portfolio invalid.");
                return null;
            }

            DateTime referenceDate;

            if (!DateTime.TryParseExact(lines[0], "MM/dd/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out referenceDate))
            {
                Notifier("Reference Date invalid.");
                return null;
            }

            bool isOk = true;

            for (int index = 2; index < numberOfTrades+2; index++)
            {
                string line = lines[index];
                string[] item = line.Split(' ');
                double value;
                DateTime nextPaymentDate;
                string clientSector = item[1];
                ITrade trade = null;

                if (!double.TryParse(item[0], out value))
                {
                    Notifier(string.Format(DefaultPhrases.DYNAMIC_INVALID_FIELD_DATA_WITH_LINE_ERROR, "value", index));
                    isOk = false;
                }

                if (!DateTime.TryParseExact(item[2], "MM/dd/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out nextPaymentDate))
                {
                    Notifier(string.Format(DefaultPhrases.DYNAMIC_INVALID_FIELD_DATA_WITH_LINE_ERROR, "next payment date", index));
                    isOk = false;
                }

                if (isOk)
                {
                    trade = new Entity.Trade(value, clientSector, nextPaymentDate);
                    var tradeValidator = new TradeValidator();
                    var tradeValidatorResult = tradeValidator.Validate(trade);
                    if (!tradeValidatorResult.IsValid)
                    {
                        foreach (var error in tradeValidatorResult.Errors)
                        {
                            Notifier(string.Format(DefaultPhrases.DYNAMIC_MESSAGE_WITH_LINE_ERROR, error.ErrorMessage, index));
                        }
                        isOk = false;
                    }
                }

                if (isOk)
                {
                    trades.Add(trade);
                }

            }

            if (!isOk)
            {
                return null;
            }

            var portfolio = new Portfolio(referenceDate, numberOfTrades, trades);

            var validator = new PortfolioValidator();
            var result = validator.Validate(portfolio);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    Notifier(string.Format(DefaultPhrases.DYNAMIC_MESSAGE_ERROR, error.ErrorMessage));
                }
                return null;

            }

            return portfolio;
        }

        void IDataProvider.LogData(string data)
        {
            string path = ConfigurationManager.AppSettings["logPath"];
            string file = DateTime.Now.ToString("yyyyMMdd") + ".txt";

            FileStream fileStream;
            FileInfo fileInfo = new FileInfo(path + "\\" + file);

            if (fileInfo.Exists)
                fileStream = fileInfo.Open(FileMode.Append, FileAccess.Write);
            else
                fileStream = fileInfo.Create();

            using (fileStream)
            {
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString());
                    writer.WriteLine();
                    writer.WriteLine(data);
                    writer.WriteLine();
                }
            }
        }
    }
}
