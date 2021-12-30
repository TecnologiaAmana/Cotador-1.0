import { useState, useEffect } from "react";
import api from './services/api'

import './App.css';
import logo from './assets/logoAmana.png'

function App() {
  const [municipios, setMunicipios] = useState([]);
  const [seguradoras, setSeguradoras] = useState([]);
  const [culturas, setCulturas] = useState([]);
  const [taxas, setTaxas] = useState([]);
  const [niveisCobertura, setNiveisCobertura] = useState([]);
  const [ufs, setUfs] = useState([]);
  const [idSeguradora, setIdSeguradora] = useState(0);
  const [idMunicipio, setIdMunicipio] = useState(0);
  const [idCultura, setIdCultura] = useState(0);
  const [idCobertura, setIdCobertura] = useState(0);
  const [plantioBuscaTaxa, setPlantioBuscaTaxa] = useState(0);



  function BuscarMunicipios() {
    api.get('Municipios').then(response => {
      if (response.status === 200) {
        setMunicipios(response.data)
      }
    })
  }

  function BuscarCulturas() {
    api.get('culturas').then(response => {
      if (response.status === 200) {
        setCulturas(response.data)
      }
    })
  }

  function BuscarSeguradoras() {
    api.get('seguradoras').then(response => {
      if (response.status === 200) {
        setSeguradoras(response.data)
      }
    })
  }

  function BuscarNiveisCobertura() {
    api.get('NivelCoberturas').then(response => {
      if (response.status === 200) {
        setNiveisCobertura(response.data)
      }
    })
  }

  function BuscarUfs() {
    api.get('ufs').then(response => {
      if (response.status === 200) {
        setUfs(response.data)
      }
    })
  }

  // function BuscarPlantio() {
  //   const data = {
  //     idMunicipio: idMunicipio,
  //     idSeguradora: idSeguradora,
  //     idCultura: idCultura
  //   }

  //   api.post('plantios', data).then(response => {
  //     if(response.status === 200) {
  //       setPlantioBuscaTaxa(response.data);
  //     }
  //   })
  // }

  function BuscarTaxas(e) {
    e.preventDefault();
    const data = {
      idMunicipio: idMunicipio,
      idSeguradora: idSeguradora,
      idCultura: idCultura,
      idCobertura: idCobertura
    }

    api.post('plantios', data).then(response => {
      if (response.status === 200) {
        api.get('taxas/' + response.data.idPlantio).then(resp => {
          if (resp.status === 200) {
            setTaxas(resp.data)
            console.log(resp.data)
            console.log('aqui agora')
          }
        })
      }
    })

  }

  useEffect(() => {
    BuscarCulturas()
    BuscarSeguradoras()
    BuscarNiveisCobertura()
    BuscarMunicipios()
    BuscarUfs()
  }, [])


  return (
    <div className="App grid">
      <header className="header">
        <img src={logo} alt="Logo amana" />
      </header>

      <main>
        <form onSubmit={BuscarTaxas}>
          <div className="row_select">

            {/* Seguradora  */}
            <div className='select_container'>
              <span className='select_title'>Seguradora</span>

              <select required onChange={(campo) => { setIdSeguradora(campo.target.value) }} className='select' name="seguradora" id="">
                <option value={0}>Todas</option>
                {seguradoras.map(seguradora => {
                  return (
                    <option key={seguradora.idSeguradora} value={seguradora.idSeguradora}>{seguradora.nomeSeguradora}</option>
                  )
                })}
              </select>

            </div>

            {/* Culturas  */}

            <div className='select_container'>
              <span className='select_title'>Cultura</span>

              <select required onChange={(campo) => setIdCultura(campo.target.value)} className='select' name="cultura" id="">
                {culturas.map(cultura => {
                  return (
                    <option key={cultura.idCultura} value={cultura.idCultura}>{cultura.nomeCultura}</option>
                  )
                })}
              </select>

            </div>

            {/* Municipios */}

            <div className='select_container'>
              <span className='select_title'>Municipios</span>

              <input onChange={(campo) => setIdMunicipio(campo.target.value)} required type='text' className='select input_mun' list="municipios" />
              <datalist id='municipios'>
                {municipios.map(m => {
                  return (<option key={m.idMunicipio} data-id={m.idMunicipio} name={m.idMunicipio} value={m.idMunicipio}>{m.nomeMunicipio}</option>)
                })}
              </datalist>

            </div>

          </div>

          <div className="row_select">
            {/* Nivel Cobertura  */}
            <div className='select_container'>
              <span className='select_title small'>Nivel de Cobertura</span>
              <select required onChange={(campo) => setIdCobertura(campo.target.value)} className='select' name="cobertura" id="">
                {niveisCobertura.map(nivel => {
                  return (
                    <option key={nivel.idNivelCobertura} value={nivel.idNivelCobertura}>{nivel.valorCobertura}</option>
                  )
                })}
              </select>
            </div>
            {/* ÁREA  */}
            <div className='select_container'>
              <span className='select_title small'>Área</span>
              <input className='select' type="number" />
            </div>
          </div>

          <div className="container_btn"><button type="submit" className='btn_calcular'>Calcular</button></div>
        </form>


        <section className="section_result">
          <div className="result_container">
            <div className="campo_resultado">
              <span className="campo_title">Segurado</span>
              <span className="campo_content">Edson Namiki</span>
            </div>
            <div className="campo_resultado">
              <span className="campo_title">CPF</span>
              <span className="campo_content">45187584945</span>
            </div>
            <div className="campo_resultado">
              <span className="campo_title">MUNICÍPIO/UF</span>
              <span className="campo_content">Perreira Barreto - SP</span>
            </div>
            <div className="campo_resultado">
              <span className="campo_title">CULTURA</span>
              <span className="campo_content">Milho Safrinha</span>
            </div>
            <div className="campo_resultado">
              <span className="campo_title">ÁREA SEGURADA</span>
              <span className="campo_content">316</span>
            </div>
            <div className="campo_resultado">
              <span className="campo_title">DATA COTAÇÃO</span>
              <span className="campo_content">23/12/2021</span>
            </div>
            <table className="table_result">
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
                        <td>100</td>
                        <td>{taxa.maxSaca}</td>
                        <td>{taxa.idNivelCoberturaNavigation.valorCobertura}</td>
                        <td>{taxa.produtivadeGarantida}</td>
                        <td>{Math.trunc(taxa.lmgabasica)}</td>
                        <td>{taxa.premioBasica.toFixed(2)}</td>
                        <td>??</td>
                        <td>??</td>
                        <td>{ }</td>
                        <td>??</td>
                      </tr>
                    )
                  })
                }
                {/* <tr>
                  <td>SWISS RE</td>
                  <td>Básica</td>
                  <td>140</td>
                  <td>110</td>
                  <td>36,95</td>
                  <td>576.533,07</td>
                  <td>64.859,00</td>
                  <td>12.971.80</td>
                  <td>51.887,20</td>
                  <td>586,11</td>
                  <td>468,89</td>
                </tr> */}
              </tbody>
            </table>
          </div>
        </section>
      </main>
    </div>
  );
}

export default App;
