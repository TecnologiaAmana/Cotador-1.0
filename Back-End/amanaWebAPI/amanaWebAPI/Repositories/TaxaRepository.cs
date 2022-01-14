using amanaWebAPI.Context;
using amanaWebAPI.Domains;
using amanaWebAPI.Interfaces;
using amanaWebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amanaWebAPI.Repositories
{
    public class TaxaRepository : ITaxaRepository
    {
        CotadorContext ctx = new CotadorContext();

        public List<Taxa> BuscarDados(TaxaViewModel taxa)
        {
            List<Taxa> taxas;

            if (taxa.Plantios == null)
            {
                taxas = ctx.Taxas
                .Select(t => new Taxa()
                {
                    IdTaxa = t.IdTaxa,
                    IdPlantio = t.IdPlantio,
                    IdNivelCobertura = t.IdNivelCobertura,
                    ValorTaxaBasica = t.ValorTaxaBasica,
                    ValorTaxaReplantio = t.ValorTaxaReplantio,
                    ProdutividadeEsperada = t.ProdutividadeEsperada,
                    MaxSaca = t.MaxSaca,
                    Area = taxa.Area,
                    Lmgareplantio = t.Lmgareplantio,
                    IdNivelCoberturaNavigation = new Nivelcobertura()
                    {
                        IdNivelCobertura = t.IdNivelCoberturaNavigation.IdNivelCobertura,
                        ValorCobertura = t.IdNivelCoberturaNavigation.ValorCobertura
                    },
                    IdPlantioNavigation = new Plantio()
                    {
                        IdPlantio = t.IdPlantioNavigation.IdPlantio,
                        IdSeguradora = t.IdPlantioNavigation.IdSeguradora,
                        IdMunicipio = t.IdPlantioNavigation.IdMunicipio,
                        IdPropriedade = t.IdPlantioNavigation.IdPropriedade,
                        IdCulturaNavigation = new Cultura()
                        {
                            IdCultura = t.IdPlantioNavigation.IdCulturaNavigation.IdCultura,
                            NomeCultura = t.IdPlantioNavigation.IdCulturaNavigation.NomeCultura
                        },

                        IdMunicipioNavigation = new Municipio()
                        {
                            IdMunicipio = t.IdPlantioNavigation.IdMunicipioNavigation.IdMunicipio,
                            NomeMunicipio = t.IdPlantioNavigation.IdMunicipioNavigation.NomeMunicipio
                        },

                        IdPropriedadeNavigation = new Propriedade()
                        {
                            IdPropriedade = t.IdPlantioNavigation.IdPropriedadeNavigation.IdPropriedade,
                            NomePropriedade = t.IdPlantioNavigation.IdPropriedadeNavigation.NomePropriedade,
                        },

                        IdSeguradoraNavigation = new Seguradora()
                        {
                            IdSeguradora = t.IdPlantioNavigation.IdSeguradoraNavigation.IdSeguradora,
                            NomeSeguradora = t.IdPlantioNavigation.IdSeguradoraNavigation.NomeSeguradora
                        }
                    },
                    ProdutivadeGarantida = (t.ProdutividadeEsperada / taxa.Area) * t.IdNivelCoberturaNavigation.ValorCobertura,
                })
                .Where(t => t.IdPlantio == taxa.IdPlantio)
                .ToList();

                foreach (Taxa item in taxas)
                {

                    item.Lmgabasica = taxa.Area * item.ProdutivadeGarantida * item.MaxSaca;

                    item.ValorLmgaReplantio = item.Lmgareplantio * item.Lmgabasica / taxa.Area;

                    item.PremioBasica = item.Lmgabasica / taxa.Area * item.ValorTaxaBasica;

                    item.PremioReplantio = item.ValorTaxaReplantio / taxa.Area * item.ValorLmgaReplantio;

                    item.PremioTotal = item.PremioReplantio + item.PremioBasica;

                    item.Subvencao = item.PremioTotal * 40 / taxa.Area;

                    if (item.Subvencao > 60000)
                    {
                        item.Subvencao = 60000;
                    }

                    item.PremioSubvencao = item.PremioTotal - item.Subvencao;

                    item.PremioMedio = item.PremioTotal / taxa.Area;

                    item.PremioMedioSubvencao = item.PremioSubvencao / taxa.Area;

                }
                return taxas;
            }

            taxas = ctx.Taxas
                .Select(t => new Taxa()
                {
                    IdTaxa = t.IdTaxa,
                    IdPlantio = t.IdPlantio,
                    IdNivelCobertura = t.IdNivelCobertura,
                    ValorTaxaBasica = t.ValorTaxaBasica,
                    ValorTaxaReplantio = t.ValorTaxaReplantio,
                    ProdutividadeEsperada = t.ProdutividadeEsperada,
                    MaxSaca = t.MaxSaca,
                    Area = taxa.Area,
                    Lmgareplantio = t.Lmgareplantio,
                    IdNivelCoberturaNavigation = new Nivelcobertura()
                    {
                        IdNivelCobertura = t.IdNivelCoberturaNavigation.IdNivelCobertura,
                        ValorCobertura = t.IdNivelCoberturaNavigation.ValorCobertura
                    },
                    IdPlantioNavigation = new Plantio()
                    {
                        IdPlantio = t.IdPlantioNavigation.IdPlantio,
                        IdSeguradora = t.IdPlantioNavigation.IdSeguradora,
                        IdMunicipio = t.IdPlantioNavigation.IdMunicipio,
                        IdPropriedade = t.IdPlantioNavigation.IdPropriedade,
                        IdCulturaNavigation = new Cultura()
                        {
                            IdCultura = t.IdPlantioNavigation.IdCulturaNavigation.IdCultura,
                            NomeCultura = t.IdPlantioNavigation.IdCulturaNavigation.NomeCultura
                        },

                        IdMunicipioNavigation = new Municipio()
                        {
                            IdMunicipio = t.IdPlantioNavigation.IdMunicipioNavigation.IdMunicipio,
                            NomeMunicipio = t.IdPlantioNavigation.IdMunicipioNavigation.NomeMunicipio
                        },

                        IdPropriedadeNavigation = new Propriedade()
                        {
                            IdPropriedade = t.IdPlantioNavigation.IdPropriedadeNavigation.IdPropriedade,
                            NomePropriedade = t.IdPlantioNavigation.IdPropriedadeNavigation.NomePropriedade,
                        },

                        IdSeguradoraNavigation = new Seguradora()
                        {
                            IdSeguradora = t.IdPlantioNavigation.IdSeguradoraNavigation.IdSeguradora,
                            NomeSeguradora = t.IdPlantioNavigation.IdSeguradoraNavigation.NomeSeguradora
                        }
                    },
                    ProdutivadeGarantida = (t.ProdutividadeEsperada / taxa.Area) * t.IdNivelCoberturaNavigation.ValorCobertura,
                })
                .Where(t => taxa.Plantios.Contains(t.IdPlantio))
                .ToList();

            foreach (Taxa item in taxas)
            {

                item.Lmgabasica = taxa.Area * item.ProdutivadeGarantida * item.MaxSaca;

                item.ValorLmgaReplantio = item.Lmgareplantio * item.Lmgabasica / taxa.Area;

                item.PremioBasica = item.Lmgabasica / taxa.Area * item.ValorTaxaBasica;

                item.PremioReplantio = item.ValorTaxaReplantio / taxa.Area * item.ValorLmgaReplantio;

                item.PremioTotal = item.PremioReplantio + item.PremioBasica;

                item.Subvencao = item.PremioTotal * 40 / taxa.Area;

                if (item.Subvencao > 60000)
                {
                    item.Subvencao = 60000;
                }

                item.PremioSubvencao = item.PremioTotal - item.Subvencao;

                item.PremioMedio = item.PremioTotal / taxa.Area;

                item.PremioMedioSubvencao = item.PremioSubvencao / taxa.Area;

            }
            return taxas;
        }

        public List<Taxa> ListarTodas()
        {
            List<Taxa> taxas = ctx.Taxas
                        .Select(t => new Taxa()
                        {
                            IdTaxa = t.IdTaxa,
                            IdPlantio = t.IdPlantio,
                            IdNivelCobertura = t.IdNivelCobertura,
                            ValorTaxaBasica = t.ValorTaxaBasica,
                            ValorTaxaReplantio = t.ValorTaxaReplantio,
                            ProdutividadeEsperada = t.ProdutividadeEsperada,
                            MaxSaca = t.MaxSaca,
                            Lmgareplantio = t.Lmgareplantio,
                            IdNivelCoberturaNavigation = new Nivelcobertura()
                            {
                                IdNivelCobertura = t.IdNivelCoberturaNavigation.IdNivelCobertura,
                                ValorCobertura = t.IdNivelCoberturaNavigation.ValorCobertura
                            },
                            IdPlantioNavigation = new Plantio()
                            {
                                IdPlantio = t.IdPlantioNavigation.IdPlantio,
                                IdSeguradora = t.IdPlantioNavigation.IdSeguradora,
                                IdMunicipio = t.IdPlantioNavigation.IdMunicipio,
                                IdPropriedade = t.IdPlantioNavigation.IdPropriedade,
                                IdCulturaNavigation = new Cultura()
                                {
                                    IdCultura = t.IdPlantioNavigation.IdCulturaNavigation.IdCultura,
                                    NomeCultura = t.IdPlantioNavigation.IdCulturaNavigation.NomeCultura
                                },

                                IdMunicipioNavigation = new Municipio()
                                {
                                    IdMunicipio = t.IdPlantioNavigation.IdMunicipioNavigation.IdMunicipio,
                                    NomeMunicipio = t.IdPlantioNavigation.IdMunicipioNavigation.NomeMunicipio
                                },

                                IdPropriedadeNavigation = new Propriedade()
                                {
                                    IdPropriedade = t.IdPlantioNavigation.IdPropriedadeNavigation.IdPropriedade,
                                    NomePropriedade = t.IdPlantioNavigation.IdPropriedadeNavigation.NomePropriedade,
                                },

                                IdSeguradoraNavigation = new Seguradora()
                                {
                                    IdSeguradora = t.IdPlantioNavigation.IdSeguradoraNavigation.IdSeguradora,
                                    NomeSeguradora = t.IdPlantioNavigation.IdSeguradoraNavigation.NomeSeguradora
                                }
                            },
                            ProdutivadeGarantida = (t.ProdutividadeEsperada / 100) * t.IdNivelCoberturaNavigation.ValorCobertura,
                        })
                        .ToList();

            foreach (Taxa item in taxas)
            {

                item.Lmgabasica = 100 * item.ProdutivadeGarantida * item.MaxSaca;

                item.ValorLmgaReplantio = item.Lmgareplantio * item.Lmgabasica / 100;

                item.PremioBasica = item.Lmgabasica / 100 * item.ValorTaxaBasica;

                item.PremioReplantio = item.ValorTaxaReplantio / 100 * item.ValorLmgaReplantio;

                item.PremioTotal = item.PremioReplantio + item.PremioBasica;

                item.Subvencao = item.PremioTotal * 40 / 100;

                if (item.Subvencao > 60000)
                {
                    item.Subvencao = 60000;
                }

                item.PremioSubvencao = item.PremioTotal - item.Subvencao;

                item.PremioMedio = item.PremioTotal / 100;

                item.PremioMedioSubvencao = item.PremioSubvencao / 100;

            }

            return taxas;
        }
    }
}
