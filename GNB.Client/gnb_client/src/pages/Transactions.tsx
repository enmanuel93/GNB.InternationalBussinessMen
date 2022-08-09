import React, { useContext, useEffect, useState } from "react";
import BootstrapTable from "react-bootstrap-table-next";
import Button from "../components/Button";
import Card from "../components/Card";
import { transactionContext } from "../hooks/transactions/transactionContext";
import Table from "../components/Table";

function Transactions() {
  const {transactionSt, getAllTransactions} = useContext(transactionContext);

  const columns = [
    { dataField: "sku", text: "Sku" },
    { dataField: "currency", text: "Currency" },
    { dataField: "amount", text: "Amount" },
  ];

  return (
    <>
      <div className="title">Transactions</div>
      <Card cardTitle="List of Transactions">
        <div>
          <div className="button-container">
            <Button type="button" onClick={() => getAllTransactions()}>Load Transactions</Button>
          </div>

          <Table data={[]} columns={columns}/>
        </div>
      </Card>
    </>
  );
}

export default Transactions;
