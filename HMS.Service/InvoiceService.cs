using HMS.Domain;
using HMS.Service;
using Invoicer.Model;
using Invoicer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bil
{
    public class InvoiceService:IInvoice
    {
        public void GetInvoice(Admin admin, User user)
        {
            new InvoicerApi(SizeOption.A4, OrientationOption.Landscape, "Rs")
                .TextColor("#CC0000")
                .BackColor("#FFD6CC")
                .Image(admin.RestaurentLogo, 125, 27)
                .Company(Address.Make("FROM", new string[] { admin.AccountName, admin.AccountName, admin.Address, admin.City, admin.PinCode}, "1471587", admin.Gst))
                .Client(Address.Make("BILLING TO", new string[] { user.Name, user.Contact, user.Email, "", "" }))
                .Items(new List<ItemRow> {
                    ItemRow.Make("dtyd", "Midnight red", (decimal)100, 18, (decimal)100, (decimal)118.00),
                    ItemRow.Make("Chiken shawarma ", "with chees", (decimal)80, 18, (decimal)80.00, (decimal)94.40),
                    ItemRow.Make("Nan chap", "Free case (blue)", (decimal)120, 18, (decimal)120, (decimal)141.60),

                })
                .Totals(new List<TotalRow> {
                    TotalRow.Make("Sub Total", (decimal)526.66),
                    TotalRow.Make("GST @ 18%", (decimal)105.33),
                    TotalRow.Make("Total", (decimal)631.99, true),
                })
                .Details(new List<DetailRow> {
                    DetailRow.Make("PAYMENT INFORMATION", "Make all cheques payable to FY5 UK Limited.", "", "If you have any questions concerning this invoice, contact our sales department at sales@FY5.co.uk.", "", "Thank you for your business.")
                })
                .Footer("http://Fy5softwarepvtltd.com")
                .Save();
        }
    }
}
