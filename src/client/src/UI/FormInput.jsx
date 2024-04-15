import React from "react";
import classes from './styles/FormInput.module.css';

function FormInput({setText, ...params}) {
    <input onChange={(event) => setText(event.target.value)} {...params}/>
}

export default FormInput;