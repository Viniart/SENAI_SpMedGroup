export const parseJwt = () => {
    let base64 = localStorage.getItem('jwt_key').split('.')[1]
    let TokenDecod = JSON.parse(window.atob(base64))
    console.log(TokenDecod)
    return TokenDecod
}

export const usuarioAutenticado = () => localStorage.getItem('jwt_key') !== null