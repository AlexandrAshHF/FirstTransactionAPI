import React, { useState } from "react";
import classes from './styles/CreateCardForm.module.css';
import FormInput from '../../UI/FormInput';

function CreateCardForm({...params}) {
    let [number, setNumber] = useState('');
    let [holderName, setHolder] = useState('');
    let [validityDate, setDate] = useState('');
    let [bankName, setBank] = useState('');
    let [network, setNetwork] = useState(0);

    return(
        <div {...params} style={{width:'300px', height:'400px', backgroundColor: 'black', margin: '100px'}}>
            <FormInput setText={setNumber} style={{width:'275px', height: '30px'}}/>
            <FormInput setText={setHolder}/>
            <FormInput setText={setBank}/>
        </div>
    );
}

export default CreateCardForm;