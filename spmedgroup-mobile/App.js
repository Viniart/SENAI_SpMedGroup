import React from 'react';
import { NavigationContainer } from '@react-navigation/native'
import { createStackNavigator } from '@react-navigation/stack';

import Login from './src/screens/login'
import Consultas from './src/screens/consultas'

const AuthStack = createStackNavigator();

 export default function Stack(){
   return(
     <NavigationContainer>
       {/* headerMode = 'none' Pra desabilitar o header  */}
       <AuthStack.Navigator>
         <AuthStack.Screen name = 'Login' component={Login} />
         <AuthStack.Screen name = 'Consultas' component={Consultas} />
       </AuthStack.Navigator>
     </NavigationContainer>
   )
 }