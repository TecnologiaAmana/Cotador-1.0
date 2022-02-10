import jsPDF from "jspdf";
import "jspdf-autotable"

const generatePDF = (taxas,municipio,segurado,cultura,data) => {
    var options = {
        pagesplit: true
    };
    const doc = new jsPDF('l', 'mm', [297, 210], 'false', options);

    const tableColumn = ["Área (HA)", "Valor Saca", "Nivel de Cobertura",
                         "Produtividade Garantida", "LMGA Básica (R$)", "LMGA Replantio (R$)",
                        "Prêmio Basica (R$)", "Prêmio Replantio (R$)", "Prêmio Total (R$)",
                        "Subvenção Federal (R$)", "Prêmio C/Desconto Subv (R$)", "Prêmio Médio S/Subv (R$/HA)",
                        "Prêmio Médio C/Subv (R$/HA)"]

    const tableRows = [];

    taxas.forEach(taxa => {
        const taxaData = [
            taxa.area,
            taxa.maxSaca,
            taxa.idNivelCoberturaNavigation.valorCobertura,
            taxa.produtivadeGarantida.toLocaleString('pt-BR', { style: 'decimal', maximumFractionDigits: 2 }),
            taxa.lmgabasica.toLocaleString('pt-BR', { style: 'decimal', maximumFractionDigits: 2 }),
            taxa.valorLmgaReplantio.toLocaleString('pt-BR', { style: 'decimal', maximumFractionDigits: 2 }),
            taxa.premioBasica.toLocaleString('pt-BR', { style: 'decimal', maximumFractionDigits: 2 }),
            taxa.premioReplantio.toLocaleString('pt-BR', { style: 'decimal', maximumFractionDigits: 2 }),
            taxa.premioTotal.toLocaleString('pt-BR', { style: 'decimal', maximumFractionDigits: 2 }),
            taxa.subvencao.toLocaleString('pt-BR', { style: 'decimal', maximumFractionDigits: 2 }),
            taxa.premioSubvencao.toLocaleString('pt-BR', { style: 'decimal', maximumFractionDigits: 2 }),
            taxa.premioMedio.toLocaleString('pt-BR', { style: 'decimal', maximumFractionDigits: 2 }),
            taxa.premioMedioSubvencao.toLocaleString('pt-BR', { style: 'decimal', maximumFractionDigits: 2 })
        ];

        tableRows.push(taxaData);

    });

    var imgData = 'data:image/png;base64,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'

    // LOGO
    doc.addImage(imgData, 'png', 15, 8, 40, 25);

    var posicaoInicial = 45;

    // SEGURADO
    doc.setFontSize(13)
    doc.text('SEGURADO',15,posicaoInicial)

    doc.setFontSize(12)
    doc.text(`${segurado}`, 80, posicaoInicial)

    // MUNICIPIO
    doc.setFontSize(13)
    doc.text('MUNICIPIO',15,(posicaoInicial+6))

    doc.setFontSize(12);
    doc.text(`${municipio.nomeMunicipio} - ${municipio.idUfNavigation.abreviacao}`,80,(posicaoInicial+6))

    // CULTURA
    doc.setFontSize(13)
    doc.text('CULTURA',15,(posicaoInicial+12))

    doc.setFontSize(12)
    doc.text(`${cultura.nomeCultura}`,80,(posicaoInicial+12))

    // DATA COTACAO
    doc.setFontSize(13)
    doc.text('DATA COTAÇÃO',15,(posicaoInicial+18))
    doc.text(`${data.toLocaleString()}`,80,(posicaoInicial+18))
        
    // var centeredText = function(text, y) {
    //     var textWidth = doc.getStringUnitWidth(text) * doc.internal.getFontSize() / doc.internal.scaleFactor;
    //     var textOffset = (doc.internal.pageSize.width - textWidth) / 2;
    //     doc.text(textOffset, y, text);
    // }

    const date = Date().split(" ");
  // we use a date string to generate our filename.
  const dateStr = date[0] + date[1] + date[2] + date[3] + date[4];
  
  const pageWidth = doc.internal.pageSize.width;  //Optional
  const pageHeight = doc.internal.pageSize.height;  //Optional
  const pages = doc.internal.getNumberOfPages();

  for (let j = 1; j < pages + 1 ; j++) {
    let horizontalPos = pageWidth / 2;  //Can be fixed number
    let verticalPos = pageHeight - 10;  //Can be fixed number
    doc.setPage(j);
    //doc.text(`${tableRows.length} registros`, horizontalPos, verticalPos, {align: 'center'  //Optional text styling});
//})
}

//   centeredText("AMANA", 35);

  // startY is basically margin-top
  doc.autoTable(tableColumn, tableRows, {
    startY : posicaoInicial+25,
    didParseCell: function (table) {
        if (table.section === 'head') {
          //table.cell.styles.textColor = '#CC2D16';
          table.cell.styles.fillColor  = '#272727';
        }
     }
  });

  doc.save(`cotacao_${dateStr}.pdf`);
}

export default generatePDF;