using DataAccessLayer.Interfaces;
using EntityLayer.ResponseModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ExportMOCKRepository : BaseRepo, IExportDal
    {
        public ExportMOCKRepository(IConfiguration config) : base(config)
        {
        }

        public InvoiceInformation GetExport(string fileNumber)
        {
            return infos.Find(e=>e.FileNumber == fileNumber);
        }
        static List<InvoiceInformation> infos = new List<InvoiceInformation>();
        public IEnumerable<InvoiceInformation> GetExports(DateTime begindate, DateTime enddate, string agentNumber)
        {
            int invNumber = 200;
            int filenumber = 3202778;
            if (infos.Count > 0)
            {
                return infos;
            }
            else
            {
                infos= new List<InvoiceInformation>()
            {
                new InvoiceInformation()
                {
                    InvoiceSerial="IIS",
                    IncoiceNumber=invNumber++.ToString(),
                    ExchangeCenter="İsko Kabiyo",//Martelli Kambiyo- Organize (Havlu) Kambiyo
                    Name="SHANGHAI ADP SUPPLY CHAIN MANAGEMENT CO.LTD.",
                    FileNumber=filenumber++.ToString(),
                    OrganizationName="AS-AV ULUSLARASI NAKLİYAT VE TİC. A.Ş.",
                    CountryKey="JP",
                    CountryName="JAPONYA",
                    CustomerNumber=new Random().Next(10000,99999).ToString(),
                    Exchange="003",
                    ShippingType="AIR", //AIR - GROUND - SEA
                    ShippingTypeDescription="UÇAK",
                    AgentNumber="",
                },
                new InvoiceInformation()
                {
                    InvoiceSerial="IIS",
                    IncoiceNumber=invNumber++.ToString(),
                    ExchangeCenter="İsko Kabiyo",//Martelli Kambiyo- Organize (Havlu) Kambiyo
                    Name="SHANGHAI ADP SUPPLY CHAIN MANAGEMENT CO.LTD.",
                    FileNumber=filenumber++.ToString(),
                    OrganizationName="AS-AV ULUSLARASI NAKLİYAT VE TİC. A.Ş.",
                    CountryKey="JP",
                    CountryName="JAPONYA",
                    CustomerNumber=new Random().Next(1000,9999).ToString(),
                    Exchange="003",
                    ShippingType="AIR",
                    ShippingTypeDescription="UÇAK",
                    AgentNumber="",
                },
                 new InvoiceInformation()
                {
                    InvoiceSerial="IIS",
                    IncoiceNumber=invNumber++.ToString(),
                    ExchangeCenter="İsko Kabiyo",//Martelli Kambiyo- Organize (Havlu) Kambiyo
                    Name="WELSPUN UK LTD",
                    FileNumber=filenumber++.ToString(),
                    OrganizationName="AS-AV ULUSLARASI NAKLİYAT VE TİC. A.Ş.",
                    CountryKey="JP",
                    CountryName="JAPONYA",
                    CustomerNumber=new Random().Next(10000,99999).ToString(),
                    Exchange="003",
                    ShippingType="GROUND", //AIR - GROUND - SEA
                    ShippingTypeDescription="TIR",
                    AgentNumber="",
                },
                new InvoiceInformation()
                {
                    InvoiceSerial="IIS",
                    IncoiceNumber=invNumber++.ToString(),
                    ExchangeCenter="İsko Kabiyo",//Martelli Kambiyo- Organize (Havlu) Kambiyo
                    Name="WELSPUN UK LTD",
                    FileNumber=filenumber++.ToString(),
                    OrganizationName="AS-AV ULUSLARASI NAKLİYAT VE TİC. A.Ş.",
                    CountryKey="JP",
                    CountryName="JAPONYA",
                    CustomerNumber=new Random().Next(1000,9999).ToString(),
                    Exchange="003",
                    ShippingType="SEA",
                    ShippingTypeDescription="GEMİ",
                    AgentNumber="",
                },
                 new InvoiceInformation()
                {
                    InvoiceSerial="IIS",
                    IncoiceNumber=invNumber++.ToString(),
                    ExchangeCenter="İsko Kabiyo",//Martelli Kambiyo- Organize (Havlu) Kambiyo
                    Name="VTL STE TUNISIENNE DE VETEMENTS DE TRAVAIL ET DE LOISIR",
                    FileNumber=filenumber++.ToString(),
                    OrganizationName="AS-AV ULUSLARASI NAKLİYAT VE TİC. A.Ş.",
                    CountryKey="TN",
                    CountryName="TUNUS",
                    CustomerNumber=new Random().Next(10000,99999).ToString(),
                    Exchange="003",
                    ShippingType="AIR", //AIR - GROUND - SEA
                    ShippingTypeDescription="UÇAK",
                    AgentNumber="",
                },
                new InvoiceInformation()
                {
                    InvoiceSerial="IIS",
                    IncoiceNumber=invNumber++.ToString(),
                    ExchangeCenter="İsko Kabiyo",//Martelli Kambiyo- Organize (Havlu) Kambiyo
                    Name="CHANGZHOU JIUCI TEXTILE AND CLOTHING CO.,LTD.",
                    FileNumber=filenumber++.ToString(),
                    OrganizationName="AS-AV ULUSLARASI NAKLİYAT VE TİC. A.Ş.",
                    CountryKey="VN",
                    CountryName="VİETNAM",
                    CustomerNumber=new Random().Next(1000,9999).ToString(),
                    Exchange="003",
                    ShippingType="AIR",
                    ShippingTypeDescription="UÇAK",
                    AgentNumber="",
                },
                 new InvoiceInformation()
                {
                    InvoiceSerial="IIS",
                    IncoiceNumber=invNumber++.ToString(),
                    ExchangeCenter="Organize (Havlu) Kambiyo",//Martelli Kambiyo- Organize (Havlu) Kambiyo
                    Name="SHANGHAI BLUE VISION INDUSTRIAL CORPORATION LIMITED",
                    FileNumber=filenumber++.ToString(),
                    OrganizationName="AS-AV ULUSLARASI NAKLİYAT VE TİC. A.Ş.",
                    CountryKey="JP",
                    CountryName="JAPONYA",
                    CustomerNumber=new Random().Next(10000,99999).ToString(),
                    Exchange="009",
                    ShippingType="GROUND", //AIR - GROUND - SEA
                    ShippingTypeDescription="TIR",
                    AgentNumber="",
                },
                new InvoiceInformation()
                {
                    InvoiceSerial="IIS",
                    IncoiceNumber=invNumber++.ToString(),
                    ExchangeCenter="İsko Kabiyo",//Martelli Kambiyo- Organize (Havlu) Kambiyo
                    Name="RAPIDNAME LTD.",
                    FileNumber=filenumber++.ToString(),
                    OrganizationName="AS-AV ULUSLARASI NAKLİYAT VE TİC. A.Ş.",
                    CountryKey="JP",
                    CountryName="JAPONYA",
                    CustomerNumber=new Random().Next(1000,9999).ToString(),
                    Exchange="003",
                    ShippingType="SEA",
                    ShippingTypeDescription="GEMİ",
                    AgentNumber="",
                },
                new InvoiceInformation()
                {
                    InvoiceSerial="IIS",
                    IncoiceNumber=invNumber++.ToString(),
                    ExchangeCenter="İsko Kabiyo",//Martelli Kambiyo- Organize (Havlu) Kambiyo
                    Name="SHANGHAI ADP SUPPLY CHAIN MANAGEMENT CO.LTD.",
                    FileNumber=filenumber++.ToString(),
                    OrganizationName="AS-AV ULUSLARASI NAKLİYAT VE TİC. A.Ş.",
                    CountryKey="JP",
                    CountryName="JAPONYA",
                    CustomerNumber=new Random().Next(10000,99999).ToString(),
                    Exchange="003",
                    ShippingType="AIR", //AIR - GROUND - SEA
                    ShippingTypeDescription="UÇAK",
                    AgentNumber="",
                },
                new InvoiceInformation()
                {
                    InvoiceSerial="IIS",
                    IncoiceNumber=invNumber++.ToString(),
                    ExchangeCenter="Organize (Havlu) Kambiyo",//Martelli Kambiyo- Organize (Havlu) Kambiyo
                    Name="SHANGHAI ADP SUPPLY CHAIN MANAGEMENT CO.LTD.",
                    FileNumber=filenumber++.ToString(),
                    OrganizationName="AS-AV ULUSLARASI NAKLİYAT VE TİC. A.Ş.",
                    CountryKey="JP",
                    CountryName="JAPONYA",
                    CustomerNumber=new Random().Next(1000,9999).ToString(),
                    Exchange="009",
                    ShippingType="AIR",
                    ShippingTypeDescription="UÇAK",
                    AgentNumber="",
                },
                 new InvoiceInformation()
                {
                    InvoiceSerial="IIS",
                    IncoiceNumber=invNumber++.ToString(),
                    ExchangeCenter="İsko Kabiyo",//Martelli Kambiyo- Organize (Havlu) Kambiyo
                    Name="WELSPUN UK LTD",
                    FileNumber=filenumber++.ToString(),
                    OrganizationName="AS-AV ULUSLARASI NAKLİYAT VE TİC. A.Ş.",
                    CountryKey="JP",
                    CountryName="JAPONYA",
                    CustomerNumber=new Random().Next(10000,99999).ToString(),
                    Exchange="003",
                    ShippingType="GROUND", //AIR - GROUND - SEA
                    ShippingTypeDescription="TIR",
                    AgentNumber="",
                },
                new InvoiceInformation()
                {
                    InvoiceSerial="IIS",
                    IncoiceNumber=invNumber++.ToString(),
                    ExchangeCenter="İsko Kabiyo",//Martelli Kambiyo- Organize (Havlu) Kambiyo
                    Name="WELSPUN UK LTD",
                    FileNumber=filenumber++.ToString(),
                    OrganizationName="AS-AV ULUSLARASI NAKLİYAT VE TİC. A.Ş.",
                    CountryKey="JP",
                    CountryName="JAPONYA",
                    CustomerNumber=new Random().Next(1000,9999).ToString(),
                    Exchange="003",
                    ShippingType="SEA",
                    ShippingTypeDescription="GEMİ",
                    AgentNumber="",
                },
                 new InvoiceInformation()
                {
                    InvoiceSerial="IIS",
                    IncoiceNumber=invNumber++.ToString(),
                    ExchangeCenter="Martelli Kambiyo",//Martelli Kambiyo- Organize (Havlu) Kambiyo
                    Name="VTL STE TUNISIENNE DE VETEMENTS DE TRAVAIL ET DE LOISIR",
                    FileNumber=filenumber++.ToString(),
                    OrganizationName="AS-AV ULUSLARASI NAKLİYAT VE TİC. A.Ş.",
                    CountryKey="TN",
                    CountryName="TUNUS",
                    CustomerNumber=new Random().Next(10000,99999).ToString(),
                    Exchange="101",
                    ShippingType="AIR", //AIR - GROUND - SEA
                    ShippingTypeDescription="UÇAK",
                    AgentNumber="",
                },
                new InvoiceInformation()
                {
                    InvoiceSerial="IIS",
                    IncoiceNumber=invNumber++.ToString(),
                    ExchangeCenter="Martelli Kambiyo",//Martelli Kambiyo- Organize (Havlu) Kambiyo
                    Name="CHANGZHOU JIUCI TEXTILE AND CLOTHING CO.,LTD.",
                    FileNumber=filenumber++.ToString(),
                    OrganizationName="AS-AV ULUSLARASI NAKLİYAT VE TİC. A.Ş.",
                    CountryKey="VN",
                    CountryName="VİETNAM",
                    CustomerNumber=new Random().Next(1000,9999).ToString(),
                    Exchange="101",
                    ShippingType="AIR",
                    ShippingTypeDescription="UÇAK",
                    AgentNumber="",
                },
                 new InvoiceInformation()
                {
                    InvoiceSerial="IIS",
                    IncoiceNumber=invNumber++.ToString(),
                    ExchangeCenter="Martelli Kambiyo",//Martelli Kambiyo- Organize (Havlu) Kambiyo
                    Name="SHANGHAI BLUE VISION INDUSTRIAL CORPORATION LIMITED",
                    FileNumber=filenumber++.ToString(),
                    OrganizationName="AS-AV ULUSLARASI NAKLİYAT VE TİC. A.Ş.",
                    CountryKey="JP",
                    CountryName="JAPONYA",
                    CustomerNumber=new Random().Next(10000,99999).ToString(),
                    Exchange="101",
                    ShippingType="GROUND", //AIR - GROUND - SEA
                    ShippingTypeDescription="TIR",
                    AgentNumber="",
                },
                new InvoiceInformation()
                {
                    InvoiceSerial="IIS",
                    IncoiceNumber=invNumber++.ToString(),
                    ExchangeCenter="Martelli Kambiyo",//Martelli Kambiyo- Organize (Havlu) Kambiyo
                    Name="RAPIDNAME LTD.",
                    FileNumber=filenumber++.ToString(),
                    OrganizationName="AS-AV ULUSLARASI NAKLİYAT VE TİC. A.Ş.",
                    CountryKey="JP",
                    CountryName="JAPONYA",
                    CustomerNumber=new Random().Next(1000,9999).ToString(),
                    Exchange="101",
                    ShippingType="SEA",
                    ShippingTypeDescription="GEMİ",
                    AgentNumber="",
                },
                new InvoiceInformation()
                {
                    InvoiceSerial="IIS",
                    IncoiceNumber=invNumber++.ToString(),
                    ExchangeCenter="İsko Kabiyo",//Martelli Kambiyo- Organize (Havlu) Kambiyo
                    Name="SHANGHAI ADP SUPPLY CHAIN MANAGEMENT CO.LTD.",
                    FileNumber=filenumber++.ToString(),
                    OrganizationName="AS-AV ULUSLARASI NAKLİYAT VE TİC. A.Ş.",
                    CountryKey="JP",
                    CountryName="JAPONYA",
                    CustomerNumber=new Random().Next(1000,9999).ToString(),
                    Exchange="003",
                    ShippingType="AIR",
                    ShippingTypeDescription="UÇAK",
                    AgentNumber="",
                },
                 new InvoiceInformation()
                {
                    InvoiceSerial="IIS",
                    IncoiceNumber=invNumber++.ToString(),
                    ExchangeCenter="İsko Kabiyo",//Martelli Kambiyo- Organize (Havlu) Kambiyo
                    Name="WELSPUN UK LTD",
                    FileNumber=filenumber++.ToString(),
                    OrganizationName="AS-AV ULUSLARASI NAKLİYAT VE TİC. A.Ş.",
                    CountryKey="JP",
                    CountryName="JAPONYA",
                    CustomerNumber=new Random().Next(10000,99999).ToString(),
                    Exchange="003",
                    ShippingType="GROUND", //AIR - GROUND - SEA
                    ShippingTypeDescription="TIR",
                    AgentNumber="",
                },
                new InvoiceInformation()
                {
                    InvoiceSerial="IIS",
                    IncoiceNumber=invNumber++.ToString(),
                    ExchangeCenter="İsko Kabiyo",//Martelli Kambiyo- Organize (Havlu) Kambiyo
                    Name="WELSPUN UK LTD",
                    FileNumber=filenumber++.ToString(),
                    OrganizationName="AS-AV ULUSLARASI NAKLİYAT VE TİC. A.Ş.",
                    CountryKey="JP",
                    CountryName="JAPONYA",
                    CustomerNumber=new Random().Next(1000,9999).ToString(),
                    Exchange="003",
                    ShippingType="SEA",
                    ShippingTypeDescription="GEMİ",
                    AgentNumber="",
                },
                 new InvoiceInformation()
                {
                    InvoiceSerial="IIS",
                    IncoiceNumber=invNumber++.ToString(),
                    ExchangeCenter="Martelli Kambiyo",//Martelli Kambiyo- Organize (Havlu) Kambiyo
                    Name="VTL STE TUNISIENNE DE VETEMENTS DE TRAVAIL ET DE LOISIR",
                    FileNumber=filenumber++.ToString(),
                    OrganizationName="AS-AV ULUSLARASI NAKLİYAT VE TİC. A.Ş.",
                    CountryKey="TN",
                    CountryName="TUNUS",
                    CustomerNumber=new Random().Next(10000,99999).ToString(),
                    Exchange="101",
                    ShippingType="AIR", //AIR - GROUND - SEA
                    ShippingTypeDescription="UÇAK",
                    AgentNumber="",
                },
                new InvoiceInformation()
                {
                    InvoiceSerial="IIS",
                    IncoiceNumber=invNumber++.ToString(),
                    ExchangeCenter="Martelli Kambiyo",//Martelli Kambiyo- Organize (Havlu) Kambiyo
                    Name="CHANGZHOU JIUCI TEXTILE AND CLOTHING CO.,LTD.",
                    FileNumber=filenumber++.ToString(),
                    OrganizationName="AS-AV ULUSLARASI NAKLİYAT VE TİC. A.Ş.",
                    CountryKey="VN",
                    CountryName="VİETNAM",
                    CustomerNumber=new Random().Next(1000,9999).ToString(),
                    Exchange="101",
                    ShippingType="AIR",
                    ShippingTypeDescription="UÇAK",
                    AgentNumber="",
                },
                 new InvoiceInformation()
                {
                    InvoiceSerial="IIS",
                    IncoiceNumber=invNumber++.ToString(),
                    ExchangeCenter="Martelli Kambiyo",//Martelli Kambiyo- Organize (Havlu) Kambiyo
                    Name="SHANGHAI BLUE VISION INDUSTRIAL CORPORATION LIMITED",
                    FileNumber=filenumber++.ToString(),
                    OrganizationName="AS-AV ULUSLARASI NAKLİYAT VE TİC. A.Ş.",
                    CountryKey="JP",
                    CountryName="JAPONYA",
                    CustomerNumber=new Random().Next(10000,99999).ToString(),
                    Exchange="101",
                    ShippingType="GROUND", //AIR - GROUND - SEA
                    ShippingTypeDescription="TIR",
                    AgentNumber="",
                },
                new InvoiceInformation()
                {
                    InvoiceSerial="IIS",
                    IncoiceNumber=invNumber++.ToString(),
                    ExchangeCenter="Organize (Havlu) Kambiyo",//Martelli Kambiyo- Organize (Havlu) Kambiyo
                    Name="RAPIDNAME LTD.",
                    FileNumber=filenumber++.ToString(),
                    OrganizationName="AS-AV ULUSLARASI NAKLİYAT VE TİC. A.Ş.",
                    CountryKey="JP",
                    CountryName="JAPONYA",
                    CustomerNumber=new Random().Next(1000,9999).ToString(),
                    Exchange="009",
                    ShippingType="SEA",
                    ShippingTypeDescription="GEMİ",
                    AgentNumber="",
                },

            };
            }
            return infos;
        }

        public Task<IEnumerable<InvoiceInformation>> GetExportsAsync(DateTime begindate, DateTime enddate, string agentNumber)
        {
            throw new NotImplementedException();
        }
    }
}
