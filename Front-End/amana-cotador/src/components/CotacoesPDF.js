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

    const details = [
        {
            table: {

            },
            layout: 'headerLineOnly'  
        }
    ];

    function Footer(currentPage, pageCount) {

        return [
            {
                text: currentPage + ' / ' + pageCount,
                alignment: 'right',
                fontSize: 9,
                margin: [2,10,20,0]

            }
        ]
    }

    const docDefinitions = {
        pageSize: 'A4',
        pageMargins: [15, 50, 15, 40],

        header: [reportTitle],
        content: [details],
        footer: [Footer]
    }



    pdfMake.createPdf(docDefinitions).download();
}

export default CotacoesPDF;