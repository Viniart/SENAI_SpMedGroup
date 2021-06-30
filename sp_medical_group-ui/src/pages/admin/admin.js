import React, { Component } from 'react'

import api from '../../services/api'

export default class Admin extends Component {
    constructor(props) {
        super(props)
        this.state = {
            consultas: [],

            Consulta: {
                paciente : 0,
                medico : 0,
                situacao : 0,
                descricao : ""
            },
            data : ""
        }
    }

    buscarConsultas = () => {

        api.get('/consultas', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('jwt_key')
            }
        })

            .then(resposta => {

                if (resposta.status === 200) {

                    this.setState({ consultas: resposta.data })

                    console.log(this.state.consultas)
                }
            })
            .catch(erro => console.log(erro));

    }

    cadastrarConsulta = (event) => {
        event.preventDefault();

        api.post('/consultas',{
                idPaciente: this.state.Consulta.paciente,
                idMedico: this.state.Consulta.medico,
                idSituacao: this.state.Consulta.situacao,
                dataConsulta: this.state.data,
                descricao: this.state.Consulta.descricao
        })
        .then(console.log('Consulta Cadastrada!'))
    }

    atualizarState = (campo) => {
        this.setState(prevState => ({
            Consulta: {
                ...prevState.Consulta,
                [campo.target.name] : campo.target.value
            }
        }))
        console.log(this.state.data)
    }

    atualizarData = (campo) => {
        this.setState({ data : campo.target.value}) 
    }

    componentDidMount() {
        this.buscarConsultas();
    }

    render() {
        return (
            <div>
                <main>
                    <section>
                        <h2>Lista de Consultas</h2>
                        <table>
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Data Consulta</th>
                                    <th>Médico</th>
                                    <th>Paciente</th>
                                </tr>
                            </thead>

                            <tbody>
                                {
                                    this.state.consultas.map(
                                        (consulta) => {
                                            return (
                                                <tr key={consulta.idConsulta}>
                                                    <td>{consulta.idConsulta}</td>
                                                    <td>{Intl.DateTimeFormat("pt-BR").format(new Date(consulta.dataConsulta))}</td>
                                                    <td>{consulta.idMedicoNavigation.nome}</td>
                                                    <td>{consulta.idPacienteNavigation.nome}</td>
                                                </tr>
                                            )
                                        }
                                    )
                                }
                            </tbody>
                        </table>
                    </section>

                    <section>
                        <h2>Cadastro de Consulta</h2>
                        <form onSubmit={this.cadastrarConsulta}>
                            <div>
                                <input 
                                    type="number"
                                    name="paciente"
                                    value={this.state.Consulta.paciente}
                                    onChange={this.atualizarState}
                                    placeholder="ID do Paciente"
                                />
                                <input 
                                    type="number"
                                    name="medico"
                                    value={this.state.Consulta.medico}
                                    onChange={this.atualizarState}
                                    placeholder="ID do Medico"
                                />
                                <input 
                                    type="number"
                                    name="situacao"
                                    value={this.state.Consulta.situacao}
                                    onChange={this.atualizarState}
                                    placeholder="ID da Situação"
                                />
                                <input 
                                    type="date"
                                    name="data"
                                    value={this.state.data}
                                    onChange={this.atualizarData}
                                />
                                <input 
                                    type="text"
                                    name="descricao"
                                    value={this.state.Consulta.descricao}
                                    onChange={this.atualizarState}
                                    placeholder="Descrição da Consulta"
                                />
                                {
                                    <button type="submit" disabled={this.state.Consulta.paciente === 0 ? 'none' : ''} >
                                        {
                                            // this.state.idTipoEventoAlterado === 0 ?
                                            // 'Cadastrar' : 'Atualizar'
                                            'Cadastrar'
                                        }
                                    </button>
                                }
                            </div>
                        </form>
                    </section>
                </main>
            </div>
        )
    }
}