import pdfMake from 'pdfmake/build/pdfmake';
import pdfFonts from 'pdfmake/build/vfs_fonts';



function CotacoesPDF (cotacoes) {
    pdfMake.vfs = pdfFonts.pdfMake.vfs;

    

}

export default CotacoesPDF;