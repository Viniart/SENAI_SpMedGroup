import React, { Component } from 'react'

import api from '../../services/api'

export default class Paciente extends Component {
    constructor(props) {
        super(props)
        this.state = {
            consultas: []
        }
    }

    buscarConsultasPaciente = () => {

        api.get('/consultas/paciente', {
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

    componentDidMount() {
        this.buscarConsultasPaciente();
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
                </main>
            </div>
        )
    }
}