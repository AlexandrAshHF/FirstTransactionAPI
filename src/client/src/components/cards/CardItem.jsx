import React, { useState } from "react";
import classes from './styles/CardItem.module.css'

function    CardItem({card, ...params})
{
    let networkImg = card.paymentNetwork === 1 ? "./images/visa.svg" : "./images/mastercard.svg";
    let selectedCur = useState(0);
    return(
        <div className={classes.cardBlock} {...params}>
            <div className={classes.upBlock}>
                <label>{card.number}</label>
                <img alt="Payment network" src={networkImg}/>
            </div>
            <div className={classes.curBlock}>
                <div className={classes.cur}>
                    <label>BYN</label>
                </div>
                <div className={classes.cur}>
                    <label>USD</label>
                </div>
                <div className={classes.cur}>
                    <label>EUR</label>
                </div>
                <div className={classes.cur}>
                    <label>RUB</label>
                </div>
            </div>
            <div className={classes.bottomBlock}>
                <label>ALEXANDR ASHEVSKY</label>
                <label>01/26</label>
            </div>
            <label>1000,24</label>
        </div>
    );
}

export default CardItem;