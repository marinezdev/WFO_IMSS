﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using static iTextSharp.text.Font;
using System.Collections.Generic;
using prop = WFO_IMSSPortal.Propiedades.Procesos.Promotoria;
using System.Globalization;

namespace WFO_IMSSPortal.Procesos.Promotoria.Cartas
{
    public partial class CartaHold : Utilerias.Comun
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int IdTramite = Convert.ToInt32(Request.Params["Id"].ToString());
                manejo_sesion = (WFO_IMSSPortal.IU.ManejadorSesion)Session["Sesion"];
                List<prop.TramitesPromotoria> tramitesPromotorias = i.promotoria.tramitespromotoria.ConsultaTramitesPromotoria(manejo_sesion.Usuarios.IdUsuario, IdTramite);

                if (tramitesPromotorias.Count > 0)
                {
                    List<prop.carta> carta = i.promotoria.cartas.Consulta_Carta(IdTramite, "Hold",1);
                    if (carta.Count > 0)
                    {
                        foreach (prop.carta DatosCarta in carta)
                        {
                            MuestraPDF(DatosCarta);
                        }
                    }
                    else
                    {
                        NoExistente();
                    }
                }
                else
                {
                    NoExistente();
                }
            }
        }

        private void MuestraPDF(prop.carta carta)
        {
            CultureInfo culture = new CultureInfo("es-MX");
            // Medidas de la hoja A4
            var document = new Document(PageSize.A4, 30, 30, 50, 50);
            document.SetMargins(30, 30, 80, 50);
            var output = new MemoryStream();
            var writer = PdfWriter.GetInstance(document, output);

            PdfPCell cell = null;

            // FORMATOS DE TEXTOS 
            Font Text = new Font(FontFamily.HELVETICA, 10, Font.NORMAL, BaseColor.BLACK);
            Font TextFooter = new Font(FontFamily.HELVETICA, 7, Font.NORMAL, BaseColor.BLACK);
            Font Negrita = new Font(FontFamily.HELVETICA, 10, Font.BOLD, BaseColor.BLACK);

            // COLOCA ENCABEZADO Y PIE DE PAGINA
            writer.PageEvent = new PDFFooter();


            // RECHAZOS 
            List<prop.motivosRechazo> motivos = i.promotoria.cartas.Consulta_MotivosRechazo(carta.Id);
            // OBSERVACIONES 
            List<prop.bitacora> ObservacionesBitacora = i.promotoria.cartas.Consulta_Observaciones_Bitacora(carta.Id);

            //DateTime FechaDB = Convert.ToDateTime(carta.FechaTermino);
            // DEFINICACION DE VARIABLES UTILIZADAS EN PLANTILLA
            string Fecha = "Ciudad de México, " + carta.FechaTermino.ToString(culture.DateTimeFormat.LongDatePattern, culture);
            string TipoTramite = carta.TipoTramite;
            string Ramo = carta.Operacion;
            string Folio = carta.FolioCompuesto;
            string Titular = "-";

            if (carta.Titular.Length > 0)
            {
                Titular = carta.Titular;
            }
            else
            {
                Titular = carta.Contratante;
            }

            string Poliza = carta.IdSisLegados;
            string Productos = carta.Producto;
            string Agente = carta.Agente;
            string Promotoria = carta.Promotoria;

            
            // INICA LA CREACION DEL PDF 
            document.Open();

            PdfPTable table = new PdfPTable(10);
            table.WidthPercentage = 100;
            table.SpacingBefore = 20;

            // ESPACIO EN BLANCO
            cell = new PdfPCell(new Phrase("", Text));
            cell.Colspan = 10;
            cell.FixedHeight = 15f;
            cell.MinimumHeight = 20F;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            table.AddCell(cell);
            cell = null;

            // FECHA 
            cell = new PdfPCell(new Phrase(Fecha, Text));
            cell.Colspan = 10;
            cell.FixedHeight = 50f;
            cell.MinimumHeight = 30f;
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.Border = 0;
            table.AddCell(cell);
            cell = null;

            // TIPO TRAMITE
            cell = new PdfPCell(new Phrase("Tipo de Trámite: ", Text));
            cell.Colspan = 2;
            cell.FixedHeight = 15f;
            cell.MinimumHeight = 15f;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            table.AddCell(cell);
            cell = null;

            cell = new PdfPCell(new Phrase(TipoTramite, Negrita));
            cell.Colspan = 8;
            cell.FixedHeight = 15f;
            cell.MinimumHeight = 15f;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            table.AddCell(cell);
            cell = null;

            // RAMO
            cell = new PdfPCell(new Phrase("Ramo: ", Text));
            cell.Colspan = 2;
            cell.FixedHeight = 15f;
            cell.MinimumHeight = 15f;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            table.AddCell(cell);
            cell = null;

            cell = new PdfPCell(new Phrase(Ramo, Negrita));
            cell.Colspan = 8;
            cell.FixedHeight = 15f;
            cell.MinimumHeight = 15f;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            table.AddCell(cell);
            cell = null;

            // FOLIO TRAMITE 
            cell = new PdfPCell(new Phrase("Folio: ", Text));
            cell.Colspan = 2;
            cell.FixedHeight = 15f;
            cell.MinimumHeight = 15f;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            table.AddCell(cell);
            cell = null;

            cell = new PdfPCell(new Phrase(Folio, Negrita));
            cell.Colspan = 10;
            cell.FixedHeight = 15f;
            cell.MinimumHeight = 15f;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            table.AddCell(cell);
            cell = null;

            // ESPACIO EN BLANCO
            cell = new PdfPCell(new Phrase("", Text));
            cell.Colspan = 10;
            cell.FixedHeight = 15f;
            cell.MinimumHeight = 50F;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            table.AddCell(cell);
            cell = null;

            // NOMBRE DEL TITULAR
            cell = new PdfPCell(new Phrase("Apreciable " + Titular, Text));
            cell.Colspan = 10;
            cell.FixedHeight = 15f;
            cell.MinimumHeight = 30f;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            table.AddCell(cell);
            cell = null;

            cell = new PdfPCell(new Phrase("En atención a tu solicitud, te indicamos que para poder continuar con el análisis, agradeceremos nos proporciones la siguiente información: ", Text));
            cell.Colspan = 10;
            cell.FixedHeight = 30f;
            cell.MinimumHeight = 30f;
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cell.Border = 0;
            table.AddCell(cell);
            cell = null;

            // EN LISTA LOS MOTIVOS DE RECHAZO
            if (motivos.Count > 0)
            {
                foreach(prop.motivosRechazo motivosRechazo in motivos)
                {
                    cell = new PdfPCell(new Phrase("   *   " + motivosRechazo.MotivoRechazo, Text));
                    cell.Colspan = 10;
                    cell.FixedHeight = 20f;
                    cell.MinimumHeight = 20f;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = 0;
                    table.AddCell(cell);
                    cell = null;
                }
            }
            else
            {
                
                cell = new PdfPCell(new Phrase("   *   NO SE ENCONTRARON MOTIVOS ", Text));
                cell.Colspan = 10;
                cell.FixedHeight = 20f;
                cell.MinimumHeight = 20f;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Border = 0;
                table.AddCell(cell);
                cell = null;
            }

           

            // ESPACIO EN BLANCO
            cell = new PdfPCell(new Phrase("", Text));
            cell.Colspan = 10;
            cell.FixedHeight = 15f;
            cell.MinimumHeight = 25F;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            table.AddCell(cell);
            cell = null;

            // OBSERVACIONES
            cell = new PdfPCell(new Phrase("OBSERVACIONES.", Negrita));
            cell.Colspan = 10;
            cell.FixedHeight = 15f;
            cell.MinimumHeight = 15f;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            table.AddCell(cell);
            cell = null;

            
            // EN LISTA LAS OBSERVACIONES DE BITACORA
            if (ObservacionesBitacora.Count > 0)
            {
                foreach (prop.bitacora observaciones in ObservacionesBitacora)
                {

                    // MOTIVOS DE HOLD OBSERVACIONES 
                    cell = new PdfPCell(new Phrase("   >   " + observaciones.Observacion, Text));
                    cell.Colspan = 10;
                    cell.FixedHeight = 20f;
                    cell.MinimumHeight = 20f;
                    cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                    cell.Border = 0;
                    table.AddCell(cell);
                    cell = null;
                }
            }
            else
            {
                // MOTIVOS DE HOLD OBSERVACIONES 
                cell = new PdfPCell(new Phrase(" > ", Text));
                cell.Colspan = 10;
                cell.FixedHeight = 20f;
                cell.MinimumHeight = 20f;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Border = 0;
                table.AddCell(cell);
                cell = null;
            }




            

            // ESPACIO EN BLANCO
            cell = new PdfPCell(new Phrase("", Text));
            cell.Colspan = 10;
            cell.FixedHeight = 15f;
            cell.MinimumHeight = 35F;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            table.AddCell(cell);
            cell = null;

            cell = new PdfPCell(new Phrase("Para poder dar continuidad a tu trámite te sugerimos hacer llegar tu información y/o respuesta a la presente en un máximo de 24 horas para evitar la suspensión de este folio.", Text));
            cell.Colspan = 10;
            cell.FixedHeight = 30f;
            cell.MinimumHeight = 30f;
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cell.Border = 0;
            table.AddCell(cell);
            cell = null;

            // ESPACIO EN BLANCO
            cell = new PdfPCell(new Phrase("", Text));
            cell.Colspan = 10;
            cell.FixedHeight = 15f;
            cell.MinimumHeight = 35F;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            table.AddCell(cell);
            cell = null;

            cell = new PdfPCell(new Phrase("Agradeceremos de antemano tu atención, quedamos a tus órdenes.", Text));
            cell.Colspan = 10;
            cell.FixedHeight = 15f;
            cell.MinimumHeight = 15f;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            table.AddCell(cell);
            cell = null;

            // ESPACIO EN BLANCO
            cell = new PdfPCell(new Phrase("", Text));
            cell.Colspan = 10;
            cell.FixedHeight = 15f;
            cell.MinimumHeight = 35F;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            table.AddCell(cell);
            cell = null;

            cell = new PdfPCell(new Phrase("Atentamente.", Text));
            cell.Colspan = 10;
            cell.FixedHeight = 15f;
            cell.MinimumHeight = 15f;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            table.AddCell(cell);
            cell = null;

            cell = new PdfPCell(new Phrase("METLIFE, MÉXICO S.A.", Text));
            cell.Colspan = 10;
            cell.FixedHeight = 15f;
            cell.MinimumHeight = 15f;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            table.AddCell(cell);
            cell = null;

            // ESPACIO EN BLANCO
            cell = new PdfPCell(new Phrase("", Text));
            cell.Colspan = 10;
            cell.FixedHeight = 15f;
            cell.MinimumHeight = 35F;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            table.AddCell(cell);
            cell = null;

            // AGENTE 
            cell = new PdfPCell(new Phrase(Agente, Text));
            cell.Colspan = 10;
            cell.FixedHeight = 15f;
            cell.MinimumHeight = 15f;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            table.AddCell(cell);
            cell = null;

            // PROMOTORIA
            cell = new PdfPCell(new Phrase(Promotoria, Text));
            cell.Colspan = 10;
            cell.FixedHeight = 15f;
            cell.MinimumHeight = 15f;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Border = 0;
            table.AddCell(cell);
            cell = null;



            document.Add(table);
            document.Close();

            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "");
            Response.BinaryWrite(output.ToArray());

        }
        
        private void NoExistente()
        {
            // Medidas de la hoja A4
            var document = new Document(PageSize.A4, 30, 30, 50, 50);
            document.SetMargins(30, 30, 80, 50);
            var output = new MemoryStream();
            var writer = PdfWriter.GetInstance(document, output);

            PdfPCell cell = null;
            Font Text = new Font(FontFamily.HELVETICA, 30, Font.BOLD, BaseColor.BLACK);

            writer.PageEvent = new PDFFooter();

            document.Open();


            PdfPTable table = new PdfPTable(10);
            table.WidthPercentage = 100;
            table.SpacingBefore = 100F;


            cell = new PdfPCell(new Phrase("\n\n\n\n\n\n\n\n DOCUMENTO NO ENCONTRADO, FAVOR DE COMUNICARTE A SOPORTE PARA VERIFICAR LA EXISTENCIA DEL ARCHIVO", Text));
            cell.Colspan = 10;
            cell.FixedHeight = 15f;
            cell.MinimumHeight = 15f;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Border = 0;
            table.AddCell(cell);
            cell = null;

            document.Add(table);
            document.Close();

            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "");
            Response.BinaryWrite(output.ToArray());
        }
    }

    public class PDFFooter : PdfPageEventHelper
    {
        // write on top of document
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            base.OnOpenDocument(writer, document);
        }

        // write on start of each page
        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);
            PdfPTable tabFot = new PdfPTable(new float[] { 1F });
            tabFot.TotalWidth = 540F;

            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance("c:\\logo_grap.jpg");
            PdfPCell imageCell = new PdfPCell(jpg);
            imageCell.Colspan = 10; // either 1 if you need to insert one cell
            imageCell.Border = 0;
            imageCell.MinimumHeight = 50f;
            imageCell.FixedHeight = 50f;
            imageCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tabFot.AddCell(imageCell);
            imageCell = null;
            tabFot.WriteSelectedRows(0, -1, 26, document.Top + 50, writer.DirectContent);
        }

        // write on end of each page
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            PdfPTable tabFot = new PdfPTable(new float[] { 1F });
            Font TextFooter = new Font(FontFamily.HELVETICA, 7, Font.NORMAL, BaseColor.BLACK);
            PdfPCell cell;
            tabFot.TotalWidth = 540F;

            //cell = new PdfPCell(new Phrase("MetLife México, S.A., Blvd. Manuel Ávila Camacho No.32, pisos SKL, 14 a 20 y PH. Col Lomas de Chapultepec, CP. 11000, Delegación Miguel Hidalgo, Ciudad de México, Tel. 5328-7000 ó lada sin costo 01-800-00 METLIFE", TextFooter));
            cell = new PdfPCell(new Phrase("MetLife México, S.A., Av. de los Insurgentes Sur 1457, Insurgentes Mixcoac, 03920 Ciudad de México, CDMX, Tel. 5328-7000 ó lada sin costo 01-800-00 METLIFE", TextFooter));
            cell.Colspan = 10;
            cell.FixedHeight = 15f;
            cell.MinimumHeight = 15f;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Border = 0;
            tabFot.AddCell(cell);
            cell = null;

            tabFot.WriteSelectedRows(0, -1, 30, document.Bottom, writer.DirectContent);
        }

        //write on close of document
        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
        }
    }
}