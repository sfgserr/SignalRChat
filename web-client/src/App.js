import React, {Component} from "react";
import { AuthProvider } from "./providers/authProvider";
import { BrowserRouter } from "react-router-dom";
import {Routes} from "./routes/routes";

function App() {
  return (
    <AuthProvider>
      <BrowserRouter children={Routes} basename={"/"} />
    </AuthProvider>
  );
}

export default App;
