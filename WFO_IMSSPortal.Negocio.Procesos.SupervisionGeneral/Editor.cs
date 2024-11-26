using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;

namespace WFO_IMSSPortal.Negocio.Procesos.SupervisionGeneral
{
    class Editor
    {
        /// <summary>
        /// Crea un párrafo de texto, con parámetros de entrada y atributos
        /// </summary>
        /// <param name="texto">Cadena de texto a mostrar</param>
        /// <param name="tamañofuente">Tamaño de la fuente</param>
        /// <param name="justificacion">Izquierda, centrado, derecha, justificado</param>
        /// <param name="bold">Negrita</param>
        /// <param name="fuente">Nombre de la fuente</param>
        /// <returns>Párrafo con las propiedades y atributos aplicados</returns>
        public Paragraph Parrafo(string texto, string tamañofuente, JustificationValues justificacion, bool bold, string fuente)
        {
            Paragraph para = new Paragraph();
            ParagraphProperties pp = new ParagraphProperties(
                    new SpacingBetweenLines() { After = "0", Before = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto }
                );
            pp.Justification = new Justification() { Val = justificacion };
            para.Append(pp);
            Run run = para.AppendChild(new Run());
            if (bold)
            {
                RunProperties runpro = new RunProperties();
                runpro.Bold = new Bold();
                run.Append(runpro);
            }
            RunProperties rp1 = new RunProperties();
            rp1.FontSize = new FontSize() { Val = tamañofuente };
            run.Append(rp1);
            RunProperties rp2 = new RunProperties(new RunFonts() { Ascii = fuente });
            run.Append(rp2);

            //RunProperties rp3 = new RunProperties(new Spacing() { Val = 0 });
            //run.Append(rp3);

            //RunProperties rp4 = new RunProperties( new SpacingBetweenLines { After = "0", Before ="0", AfterLines = 0 , BeforeLines = 0, LineRule = LineSpacingRuleValues.Exact } );
            //run.Append(rp4);


            run.AppendChild(new Text(texto));
            return para;
        }

        /// <summary>
        /// Concatena un parrafo con dos textos, propiedades distintas para el segundo texto
        /// </summary>
        /// <param name="texto1"></param>
        /// <param name="texto2"></param>
        /// <param name="tamañofuente"></param>
        /// <param name="justificacion"></param>
        /// <param name="bold"></param>
        /// <param name="italica"></param>
        /// <param name="subrayado"></param>
        /// <returns></returns>
        public Paragraph ParrafoConcatenado(string texto1, string texto2, string tamañofuente, JustificationValues justificacion, bool bold, bool italica, bool subrayado)
        {
            Paragraph para = new Paragraph();
            ParagraphProperties pp = new ParagraphProperties(
                    new SpacingBetweenLines() { After = "0", Before = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto }
                );
            pp.Justification = new Justification() { Val = justificacion };
            para.Append(pp);
            Run run1 = para.AppendChild(new Run());
            RunProperties runpro1 = new RunProperties();
            runpro1.FontSize = new FontSize() { Val = tamañofuente };
            run1.Append(runpro1);
            run1.AppendChild(new Text(texto1) { Space = SpaceProcessingModeValues.Preserve });

            Run run2 = para.AppendChild(new Run());
            RunProperties runpro2 = new RunProperties();
            if (bold)
                runpro2.Bold = new Bold();
            if (italica)
                runpro2.Italic = new Italic();
            if (subrayado)
                runpro2.Underline = new Underline();
            run2.Append(runpro2);

            RunProperties runpro5 = new RunProperties();
            runpro5.FontSize = new FontSize() { Val = tamañofuente };
            run2.Append(runpro5);

            run2.AppendChild(new Text(texto2));

            return para;

        }

        /// <summary>
        /// Concatena un parrafo con tres textos, propiedades distintas para el texto intermedio
        /// </summary>
        /// <param name="texto1"></param>
        /// <param name="texto2"></param>
        /// <param name="texto3"></param>
        /// <param name="tamañofuente"></param>
        /// <param name="justificacion"></param>
        /// <param name="bold"></param>
        /// <param name="italica"></param>
        /// <param name="subrayado"></param>
        /// <returns></returns>
        public Paragraph ParrafoConcatenado(string texto1, string texto2, string texto3, string tamañofuente, JustificationValues justificacion, bool bold, bool italica, bool subrayado)
        {
            Paragraph para = new Paragraph();
            ParagraphProperties pp = new ParagraphProperties(
                    new SpacingBetweenLines() { After = "0", Before = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto }
                );
            pp.Justification = new Justification() { Val = justificacion };
            para.Append(pp);
            Run run1 = para.AppendChild(new Run());
            RunProperties runpro1 = new RunProperties();
            runpro1.FontSize = new FontSize() { Val = tamañofuente };
            run1.Append(runpro1);
            run1.AppendChild(new Text(texto1) { Space = SpaceProcessingModeValues.Preserve });

            Run run2 = para.AppendChild(new Run());
            RunProperties runpro2 = new RunProperties();
            if (bold)
            {
                runpro2.Bold = new Bold();
            }
            if (italica)
            {
                runpro2.Italic = new Italic();
            }
            if (subrayado)
            {
                runpro2.Underline = new Underline();
            }
            run2.Append(runpro2);

            RunProperties runpro5 = new RunProperties();
            runpro5.FontSize = new FontSize() { Val = tamañofuente };
            run2.Append(runpro5);

            run2.AppendChild(new Text(texto2));

            Run run3 = para.AppendChild(new Run());
            RunProperties runpro3 = new RunProperties();
            runpro3.FontSize = new FontSize() { Val = tamañofuente };
            run3.Append(runpro3);
            run3.AppendChild(new Text(texto3) { Space = SpaceProcessingModeValues.Preserve });

            return para;
        }

        public Table Tabla(TableRow fila)
        {
            Table table = new Table();
            TableProperties tableprop = new TableProperties
            (
                new SpacingBetweenLines() { After = "0", Before = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto },

                new TableBorders(new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Sawtooth), Size = 5 },
                new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Sawtooth), Size = 5 },
                new LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.Sawtooth), Size = 5 },
                new RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.Sawtooth), Size = 5 },
                new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Sawtooth), Size = 5 },
                new InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Sawtooth), Size = 5 })
            );
            table.AppendChild(tableprop);

            table.Append(fila);

            return table;
        }

        public TableRow FilaTabla(TableCell[] celda)
        {
            TableRow tr1 = new TableRow();
            tr1.Append(celda);
            return tr1;
        }

        public TableCell Celda(string texto, DocumentFormat.OpenXml.Wordprocessing.JustificationValues justificacion, bool negrita, string colorHex, string tamañofuente)
        {
            TableCell tc = new TableCell();
            tc.Append(
                new TableCellProperties(
                    new SpacingBetweenLines() { After = "0", Before = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto },
                    new TableCellWidth() { 
                        Type = TableWidthUnitValues.Dxa, 
                        Width = "3000" 
                    }
                )
            );
            TableCellProperties tcp = new TableCellProperties(
                    new SpacingBetweenLines() { After = "0", Before = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto }
                );

            tcp.Append(
                new Shading() {
                    Color = "auto",
                    Fill = colorHex,
                    Val = ShadingPatternValues.Clear
                    //ThemeFill = ThemeColorValues.Text2
                }
            ); //"548DD4"
            tc.Append(tcp);

            Paragraph prg = new Paragraph();
            ParagraphProperties pp = new ParagraphProperties(
                    new SpacingBetweenLines() { After = "0", Before = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto }
                );
            pp.Justification = new Justification() { Val = justificacion };
            prg.Append(pp);
            Run r = new Run();
            RunProperties rp = new RunProperties(
                    new SpacingBetweenLines() { After = "0", Before = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto }
                );
            if (negrita)
                rp.Bold = new Bold();
            r.Append(rp);
            RunProperties rp1 = new RunProperties(
                    new SpacingBetweenLines() { After = "0", Before = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto }
                );
            rp1.FontSize = new FontSize() { Val = tamañofuente };
            r.Append(rp1);
            r.Append(new Text(texto));
            prg.Append(r);

            tc.Append(prg);
            return tc;
        }
    }
}
