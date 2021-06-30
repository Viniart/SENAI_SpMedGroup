import React, { Component } from 'react'

import api from '../../services/api'

export default class Medico extends Component {
    constructor(props) {
        super(props)
        this.state = {
            consultas: [],

            descricao: "",
            id: 0
        }
    }

    buscarConsultasMedico = () => {

        api.get('/consultas/medico', {
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

    atualizarDescricao = (event) => {
        event.preventDefault();

        api.patch('/consultas/' + this.state.id, {
            descricao: this.state.descricao
        }, {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('jwt_key')
            }
        }
        )
        .then(console.log('Consulta Atualizada!'))
        .then(this.buscarConsultasMedico)
    }

    atualizarCampos = (campo) => {
        this.setState({ [campo.target.name] : campo.target.value}) 
        console.log(this.state.descricao)
        console.log(this.state.id)
    }

    componentDidMount() {
        this.buscarConsultasMedico();
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
                                    <th>Descrição</th>
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
                                                    <td>{consulta.descricao}</td>
                                                </tr>
                                            )
                                        }
                                    )
                                }
                            </tbody>
                        </table>
                    </section>

                    <section>
                        <h2>Atualizar Descrição</h2>
                        <form onSubmit={this.atualizarDescricao}>
                            <div>
                                <input 
                                    type="text"
                                    name="descricao"
                                    value={this.state.descricao}
                                    onChange={this.atualizarCampos}
                                    placeholder="Descrição"
                                />
                                <input 
                                    type="number"
                                    name="id"
                                    value={this.state.id}
                                    onChange={this.atualizarCampos}
                                    placeholder="ID da Consulta a ser Atualizada"
                                />
                                {
                                    <button type="submit" disabled={this.state.id <= 0 ? 'none' : ''} >
                                        {
                                            'Atualizar'
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