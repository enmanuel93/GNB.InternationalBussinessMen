import React, { useState, useEffect, useContext } from "react";
import Button from "../components/Button";
import Card from "../components/Card";
import Table from "../components/Table";

import { rateContext } from "../hooks/rates/rateContext";

function Rates() {
  const {ratesState, getAllRates} = useContext(rateContext);
  const {rates} = ratesState;

  const columns = [    
    { dataField: "id", text: "ID" },
    { dataField: "from", text: "From" },
    { dataField: "to", text: "To" },
    { dataField: "rate", text: "Rate" },
  ];

  return (
    <>
      <div className="title">Rates</div>
      <Card cardTitle="List of Rates">
        <div>
          <div className="button-container">
            <Button type="button" onClick={() => getAllRates()}>Load Rates</Button>
          </div>
          <Table data={rates} columns={columns}/>
        </div>
      </Card>
    </>
  );
}

export default Rates;
