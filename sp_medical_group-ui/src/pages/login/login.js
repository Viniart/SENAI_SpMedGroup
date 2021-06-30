import React, {Component} from "react"
import { parseJwt, usuarioAutenticado } from "../../services/auth"

import api from "../../services/api"

export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {

            Usuario: {
                email : "",
                senha : ""
            },

            erroMensagem : "",
            isLoading : false
        }

        if(usuarioAutenticado() === true){
            this.props.history.push('/')
        }
    }
    
    login = (event) => {
        event.preventDefault()

        this.setState({ erroMensagem: "", isLoading: true })

        api.post("/login", {
            Email: this.state.Usuario.email,
            Senha: this.state.Usuario.senha
        })
        .then(response => {
            if (response.status === 200){
                this.setState({ isLoading: false })

                localStorage.setItem("jwt_key", response.data.token)

                if(parseJwt().role === "1"){
                    this.props.history.push('/admin')
                }
                else if(parseJwt().role === "2"){
                    this.props.history.push('/medico')
                }
                else if(parseJwt().role === "3"){
                    this.props.history.push('/paciente')
                }
                else{
                    this.props.history.push('/login')
                    this.setState({erroMensagem : "Conta Inválida!"})
                }
            }
            console.log(parseJwt().role)
        })
        .catch(error => {
            console.log(error)
            this.setState({erro : "Email ou senha incorretos"})
        })
    }

    atualizarState = (campo) => {
        // this.setState({ [campo.target.name] : campo.target.value})
        this.setState(prevState => ({
            Usuario: {
                ...prevState.Usuario,
                [campo.target.name] : campo.target.value
            }
        }))
    }

    render() {
        return (
            <>
                <h1>Faça login para continuar</h1>
                <form onSubmit={this.login}><div>
                    <input name="email" type="email" value={this.state.Usuario.email} onChange={this.atualizarState}/>
                    <input name="senha" type="password" value={this.state.Usuario.senha} onChange={this.atualizarState}/>
                    <button type="submit">Login</button></div>
                </form>
            </>
        )
    }
}