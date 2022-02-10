import '../App.css';
import * as React from "react";
import { Header } from '../components/Header';
import { TableResult } from '../components/Table';
import ReactToPrint, { useReactToPrint } from 'react-to-print';


export const PageToPrint = () => {
    return (
        <div id='printer'>
            <Header />
            <TableResult />
        </div>
    )
}

export const Print = async () => {
    const componentRef = React.useRef(null);

    const handlePrint = useReactToPrint({
        content: PageToPrint,
        documentTitle: "AwesomeFileName",
        removeAfterPrint: true
    })
    
    return (
        <div>
            <button onClick={handlePrint}>Teste</button>
        </div>
    )
}