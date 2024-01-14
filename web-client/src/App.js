import React, { Component } from "react";
import { AuthProvider } from "./providers/authProvider";
import { BrowserRouter } from "react-router-dom";
import { Routes } from "./routes/routes";


export class App extends Component {
  render() {
    console.log(process.env.REACT_APP_IDENTITY_CLIENT_ID);
    return (
      <AuthProvider>
        <BrowserRouter children={Routes} basename={"/"} />
      </AuthProvider>
    );
  }
}
