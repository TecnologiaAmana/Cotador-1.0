import { useState, useEffect } from "react";
import api from './services/api'

import './App.css';
import CotacoesPDF from "./components/CotacoesPDF";
import logo from './assets/logoAmana.png'
import { TableResult } from "./components/Table";
import { Header } from "./components/Header";
import generatePDF from "./services/jsPdfPrinter";

function App() {
  const [seguradoras, setSeguradoras] = useState([]);
  const [culturas, setCulturas] = useState([]);
  const [municipios, setMunicipios] = useState([]);
  const [idSeguradora, setIdSeguradora] = useState(0);
  const [idMunicipio, setIdMunicipio] = useState(0);
  const [idCultura, setIdCultura] = useState(0);
  const [area, setArea] = useState(0);
  const [taxas, setTaxas] = useState([]);
  const [data, setData] = useState(new Date());
  const [cliente, setCliente] = useState("");
  const [culturaBuscada, setCulturaBuscada] = useState({});

  const [municipioBuscado, setMunicipioBuscado] = useState({})

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


  function BuscaMunicipioPeloID(idMunicipio) {
    api.get("Municipios/" + idMunicipio)
      .then(resp => {
        if (resp.status === 200) {
          setMunicipioBuscado(resp.data)
        }
      })
  }

  function BuscarTaxas(e) {
    e.preventDefault();
    BuscaMunicipioPeloID(idMunicipio);
    setTaxas([])
    setData(new Date())

    const dataPlantio = {
      IdMunicipio: idMunicipio,
      IdSeguradora: idSeguradora,
      IdCultura: idCultura,
    }

    api.get("culturas/" + idCultura).then(response => {
      if (response.status === 200) {
        setCulturaBuscada(response.data)
        console.log(response.data)
      }
    })

    api.post('plantios', dataPlantio).then(response => {

      if (response.status === 200) {

        var dataTaxa;

        if (response.data.idMunicipio !== undefined) {
          dataTaxa = {
            IdPlantio: response.data.idPlantio,
            Area: area,
          }
        }
        else {
          dataTaxa =
          {
            Plantios: response.data,
            Area: area
          }

        }
        api.post('taxas', dataTaxa).then(resp => {

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
    BuscarMunicipios()
  }, [])


  return (
    <div className="App grid">
      <Header />
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

              <select onChange={(campo) => setIdMunicipio(campo.target.value)} required className='select' name="municipio">
                {municipios.map(m => {
                  return (<option key={m.idMunicipio} name={m.idMunicipio} value={m.idMunicipio}>{m.nomeMunicipio} - {m.idUfNavigation.abreviacao}</option>)
                }) }
              </select>

              {/* <input onChange={(campo) => setIdMunicipio(campo.target.value)} required type='text' className='select input_mun' list="municipios" />
              <datalist id='municipios'>
                {municipios.map(m => {
                  return (<option key={m.idMunicipio} data-id={m.idMunicipio} name={m.idMunicipio} value={m.idMunicipio}>{m.nomeMunicipio}</option>)
                })}
              </datalist> */}

            </div>

          </div>

          <div className="row_select">

            {/* ÁREA  */}
            <div className='select_container'>
              <span className='select_title small'>Área</span>
              <input required onChange={(campo) => setArea(campo.target.value)} className='select padding_input' type="number" />
            </div>
            
            {/* CLIENTES  */}
            <div className='select_container'>
              <span className='select_title small'>Cliente</span>
              <input onChange={(campo) => setCliente(campo.target.value)} className='select padding_input' value={cliente} type="text" name="" id="" />
            </div>
          </div>

          <div className="container_btn"><button type="submit" className='btn_calcular'>Calcular</button></div>
        </form>

        <div id="resultado_div">
          <section id="resultado" className="section_result">
            <div className="result_container">
              <div className="campo_resultado">
                <span className="campo_title">Segurado</span>
                <span className="campo_content">{cliente}</span>
              </div>
              {Object.keys(municipioBuscado).length === 0 ? <span></span> :
                <div className="campo_resultado">
                  <span className="campo_title">Municipio</span>
                  <span className="campo_content">{municipioBuscado.nomeMunicipio + " - " + municipioBuscado.idUfNavigation.abreviacao}</span>
                </div>}
              {Object.keys(culturaBuscada).length === 0 ? <span></span> :
          
              <div className="campo_resultado">
                <span className="campo_title">CULTURA</span>
                <span className="campo_content">{culturaBuscada.nomeCultura}</span>
              </div>
              }
          
              <div className="campo_resultado">
                <span className="campo_title">DATA COTAÇÃO</span>
                <span className="campo_content">{Intl.DateTimeFormat("pt-BR", {
                  year: 'numeric', month: 'numeric', day: "numeric"
                }).format(data)}</span>
              </div>
              {TableResult(taxas)}
            </div>

            <button className="btnGerarPdf" onClick={() => {generatePDF(taxas,municipioBuscado,cliente,culturaBuscada,data)}}>Gerar PDf Completo</button>
          </section>
        </div>
      </main>
    </div>
  );
}

export default App;
