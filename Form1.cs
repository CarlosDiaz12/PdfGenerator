using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfGenerator.Data;
using Image = iTextSharp.text.Image;

namespace PdfGenerator
{
    public partial class Form1 : Form
    {
        private AppDbContext appDbContext;
        public Form1(string noCheque)
        {
            InitializeComponent();
            appDbContext = new AppDbContext();
            GetInfoFromDb(noCheque);
        }

        private Cheque GetData(string noCheque)
        {
            long value = Convert.ToInt64(noCheque);
            return appDbContext.Cheques.FirstOrDefault(x => x.NumeroCheque == value);
        }

        void GetInfoFromDb(string noCheque)
        {
            // traer informacion del cheque y generar el pdf
            Cheque data = GetData(noCheque);
            GenerateAndOpenFile(data);
        }

        void GenerateAndOpenFile(Cheque info)
        {
            try
            {

                Document document = new Document(PageSize.Letter);
                FileStream ms = new FileStream(Path.Combine(Environment.CurrentDirectory, "file.pdf"), FileMode.Create);
                PdfWriter.GetInstance(document, ms);

                document.AddAuthor("App Cheques");
                //document.AddTitle($"Cheque No. {info.NumeroCheque}");
                document.Open();

                Image banner = Image.GetInstance(Path.Combine(Environment.CurrentDirectory, "cheque_template.png"));
                banner.SetAbsolutePosition(0, document.GetTop(250));

                document.Add(banner);

                PdfPTable table = new PdfPTable(2);
                table.WidthPercentage = 30;


                var fecha = new Paragraph();
                fecha.Add(new Chunk("\n"));
                fecha.Add(new Chunk("\n"));
                fecha.Add(new Paragraph(info.FechaPago.ToString("yyyy/MM/dd")));

                table.AddCell(new PdfPCell() { Border = 0 });
                table.AddCell(new PdfPCell(fecha) { Border = 0 , HorizontalAlignment =  Element.ALIGN_RIGHT });
                document.Add(table);


                PdfPTable table2 = new PdfPTable(2);
                table2.SpacingBefore = 62;
                table2.WidthPercentage = 100;


                var cliente = new Paragraph();
                fecha.Add(new Chunk("\n"));
                fecha.Add(new Chunk("\n"));
                cliente.Add(new Paragraph(info.NombreCliente));

                table2.AddCell(new PdfPCell(cliente) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

                var monto = new Paragraph();
                monto.Add(new Paragraph(info.Monto.ToString()));

                table2.AddCell(new PdfPCell(monto) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });

                document.Add(table2);

                PdfPTable table3 = new PdfPTable(1);
                table3.SpacingBefore = 25;
                table3.WidthPercentage = 100;


                var montoLetra = new Paragraph();
                montoLetra.Add(new Paragraph(info.MontoLetra + "PESOS DOMINICANOS"));

                table3.AddCell(new PdfPCell(montoLetra) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });


                document.Add(table3);


                document.Close();
                ms.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
