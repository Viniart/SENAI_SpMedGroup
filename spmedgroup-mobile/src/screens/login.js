import React, { Component } from 'react';
import { StyleSheet , Text , TextInput , Pressable , View } from 'react-native';
import  AsyncStorage  from '@react-native-async-storage/async-storage';

import api from '../services/api';

export default class Login extends Component {
    constructor(props){
        super(props);
        this.state = {
            email : '',
            senha : ''
        }
    }

    // Lembrar que assíncrono é uma forma de trabalhar com promises
    realizarLogin = async () => {
        try {
            const resposta = await api.post('/Login', {
                email : this.state.email,
                senha : this.state.senha
            }) 

            console.warn(this.state.email)
            console.warn(this.state.senha)

            const token = resposta.data.token;

            await AsyncStorage.setItem('userToken', token);

            console.warn(token)

            this.props.navigation.navigate('Consultas');


        } catch(erro) {
            console.warn(erro)
        }
    };

    render(){
        return(
            <View style={styles.overlay}>
                <View style={styles.main}>
                    <TextInput 
                        style={styles.inputLogin}
                        placeholder="Username"
                        keyboardType="email-address"
                        onChangeText={email => this.setState({ email })}
                    />
                    <TextInput 
                        style={styles.inputLogin}
                        placeholder="Password"
                        secureTextEntry={true}
                        onChangeText={senha => this.setState({ senha })}
                    />

                    <Pressable
                        style={styles.btnLogin}
                        onPress={this.realizarLogin}
                    >
                        <Text style={styles.btnLoginText}>Login</Text>
                    </Pressable>
                </View>
            </View>
        )
    }
}

const styles = StyleSheet.create({
    overlay: {
        ...StyleSheet.absoluteFillObject,
        backgroundColor: '#2AEBE9'
    },

    main: {
        width: '100%',
        height: '100%',
        alignItems: 'center',
        justifyContent: 'center'
    },

    inputLogin: {
        width: 200,
        marginBottom: 40,
        fontSize: 20,
        color: '#FFF',
        borderColor: '#FFF',
        borderWidth: 2,
        borderRadius: '15px'
    },

    btnLogin: {
        alignItems: 'center',
        justifyContent: 'center',
        height: 35,
        width: 240,
        backgroundColor: '#FFF',
        borderColor: '#FFF',
        borderWidth: 1,
        borderRadius: 4,
        marginTop: 20
    },

    btnLoginText: {
        fontSize: 12,
        fontFamily: 'Arial',
        color: '#F52D22',
        textTransform: 'uppercase'
    }
});