using ConstructionCostEstimator.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace ConstructionCostEstimator.Services;

public class PdfService
{
    public byte[] GenerateProjectReport(ProjectReport report)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        return Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Margin(40);

                page.Header()
                .Column(header =>
                {
                    header.Item()
                        .Text("Construction Cost Report")
                        .FontSize(24)
                        .Bold()
                        .FontColor(Colors.Blue.Darken2);

                    header.Item()
                        .Text($"Generated on: {DateTime.Now:MMMM dd, yyyy}")
                        .FontSize(10)
                        .FontColor(Colors.Grey.Darken2);

                    header.Item().PaddingBottom(15);
                });

                page.Content()
                    .Column(column =>
                    {
                        column.Spacing(15);

                        column.Item()
                            .Text("Project Information")
                            .FontSize(16)
                            .Bold();

                        column.Item()
                            .Border(1)
                            .Padding(10)
                            .Column(info =>
                            {
                                info.Item().Text($"Project: {report.ProjectName}");
                                info.Item().Text($"Description: {report.Description}");
                                info.Item().Text($"Status: {report.Status}");

                                if (report.StartDate.HasValue)
                                    info.Item().Text($"Start Date: {report.StartDate:MM/dd/yyyy}");

                                if (report.EndDate.HasValue)
                                    info.Item().Text($"End Date: {report.EndDate:MM/dd/yyyy}");
                            });

                        column.Item().PaddingTop(20);

                        column.Item()
                            .Text("Material Breakdown")
                            .FontSize(16)
                            .Bold()
                            .FontColor(Colors.Orange.Darken2);

                        column.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(3);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(2);
                            });

                            table.Header(header =>
                            {
                                header.Cell().Element(CellStyle).Text("Material");
                                header.Cell().Element(CellStyle).AlignRight().Text("Qty");
                                header.Cell().Element(CellStyle).AlignRight().Text("Unit Cost");
                                header.Cell().Element(CellStyle).AlignRight().Text("Total");
                            });

                            foreach (var item in report.MaterialBreakdown)
                            {
                                table.Cell().Element(DataStyle).Text(item.Name);

                                table.Cell().Element(DataStyle)
                                    .AlignRight()
                                    .Text(item.Quantity.ToString());

                                table.Cell().Element(DataStyle)
                                    .AlignRight()
                                    .Text(item.UnitCost.ToString("C"));

                                table.Cell().Element(DataStyle)
                                    .AlignRight()
                                    .Text(item.Total.ToString("C"));
                            }
                        });

                        column.Item()
                        .AlignRight()
                        .PaddingTop(10)
                        .Text($"Material Total: {report.TotalMaterialCost:C}")
                        .Bold()
                        .FontSize(14);
                    });

                page.Footer()
                    .AlignCenter()
                    .Text(x =>
                    {
                        x.Span("Page ");
                        x.CurrentPageNumber();
                    });
            });
        }).GeneratePdf();
    }

    private static IContainer CellStyle(IContainer container)
    {
        return container
            .BorderBottom(1)
            .Padding(5)
            .Background(Colors.Grey.Lighten3);
    }

    private static IContainer DataStyle(IContainer container)
    {
        return container
            .BorderBottom(1)
            .Padding(5);
    }
}