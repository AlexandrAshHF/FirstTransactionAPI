import React from "react";
import classes from './styles/CardList.module.css';
import CardItem from './CardItem';

function CardList({cards, ...params}) {
    return(
        <div className={classes.mainBlock} {...params}>
            {cards.map((item) => (
                <CardItem card={item}/>
            ))}
        </div>
    );
}

export default CardList;