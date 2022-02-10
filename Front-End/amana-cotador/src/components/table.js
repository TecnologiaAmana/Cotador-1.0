import '../App.css';


export const TableResult = (taxas) => {
    return (
        <table className="table_result" id="main_table">
            <thead>
                <tr>
                    <th>Seguradora</th>
                    <th>Área (HA)</th>
                    <th>Valor Saca</th>
                    <th>Nivel de Cobertura</th>
                    <th>Produtividade Garantida</th>
                    <th>LMGA Básica (R$)</th>
                    <th>LMGA Replantio (R$)</th>
                    <th>Prêmio Basica (R$)</th>
                    <th>Prêmio Replantio (R$)</th>
                    <th>Prêmio Total (R$)</th>
                    <th>Subvenção Federal (R$)</th>
                    <th>Prêmio C/Desconto Subv (R$)</th>
                    <th>Prêmio Médio S/Subv (R$/HA)</th>
                    <th>Prêmio Médio C/Subv (R$/HA)</th>
                </tr>
            </thead>
            <tbody>
                {
                    taxas.map(taxa => {
                        return (
                            <tr key={taxa.idTaxa}>
                                <td>{taxa.idPlantioNavigation.idSeguradoraNavigation.nomeSeguradora}</td>
                                <td>{taxa.area}</td>
                                <td>{taxa.maxSaca}</td>
                                <td>{taxa.idNivelCoberturaNavigation.valorCobertura}</td>
                                <td>{taxa.produtivadeGarantida.toLocaleString('pt-BR', { style: 'decimal', maximumFractionDigits: 2 })}</td>
                                <td>{taxa.lmgabasica.toLocaleString('pt-BR', { style: 'decimal', maximumFractionDigits: 2 })}</td>
                                <td>{taxa.valorLmgaReplantio.toLocaleString('pt-BR', { style: 'decimal', maximumFractionDigits: 2 })}</td>
                                <td>{taxa.premioBasica.toLocaleString('pt-BR', { style: 'decimal', maximumFractionDigits: 2 })}</td>
                                <td>{taxa.premioReplantio.toLocaleString('pt-BR', { style: 'decimal', maximumFractionDigits: 2 })}</td>
                                <td>{taxa.premioTotal.toLocaleString('pt-BR', { style: 'decimal', maximumFractionDigits: 2 })}</td>
                                <td>{taxa.subvencao.toLocaleString('pt-BR', { style: 'decimal', maximumFractionDigits: 2 })}</td>
                                <td>{taxa.premioSubvencao.toLocaleString('pt-BR', { style: 'decimal', maximumFractionDigits: 2 })}</td>
                                <td>{taxa.premioMedio.toLocaleString('pt-BR', { style: 'decimal', maximumFractionDigits: 2 })}</td>
                                <td>{taxa.premioMedioSubvencao.toLocaleString('pt-BR', { style: 'decimal', maximumFractionDigits: 2 })}</td>
                            </tr>
                        )
                    })
                }
            </tbody>
        </table>
    )
}