import pdfMake from 'pdfmake/build/pdfmake';
import pdfFonts from 'pdfmake/build/vfs_fonts';



function CotacoesPDF (cotacoes) {
    pdfMake.vfs = pdfFonts.pdfMake.vfs;

    const reportTitle = [
        {
            text: 'This is a header, using header style',
            fontSize: 15,
            bold: true,
            margin: [15,20,0,45]
        }
    ];

    const details = [];

    const footer = [];

    const docDefinitions = {
        pageSize: 'A4',
        pageMargins: [15, 50, 15, 40],

        header: [reportTitle],
        content: [details],
        footer: [footer]
    }



    pdfMake.createPdf(docDefinitions).download();
}

export default CotacoesPDF;