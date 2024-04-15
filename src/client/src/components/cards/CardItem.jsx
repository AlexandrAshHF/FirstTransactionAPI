import React, { useState } from "react";
import classes from './styles/CardItem.module.css'

const currencyLabels = {
    1: 'BYN',
    431: 'USD',
    451: 'EUR',
    456: 'RUB',
};

function getCurrencyLabel(number) {
    return currencyLabels[number] || 'NON';
}

function CardItem({card, ...params})
{
    let networkImg = card.network === 1 ? "./images/visa.svg" : "./images/mastercard.svg";
    let [selectedCur, setSelectedCur] = useState(card.balanceAccounts[0].item1);
    let [balance, setBalance] = useState(card.balanceAccounts[0].item2);

    return(
        <div className={classes.cardBlock} {...params}>
            <div className={classes.upBlock}>
                <label>{card.number}</label>
                <img alt="Payment network" src={networkImg}/>
            </div>
            <div className={classes.curBlock}>
                {card.balanceAccounts.map((currency) => (
                    <div className={currency.item1 != selectedCur ? classes.cur : classes.selectedCur}>
                        <label>{getCurrencyLabel(currency.item1)}</label>
                    </div>
                ))}
            </div>
            <div className={classes.bottomBlock}>
                <label>{card.holderName}</label>
                <label>{card.validityDate}</label>
            </div>
            <label>{balance}</label>
        </div>
    );
}

export default CardItem;