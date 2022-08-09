import React, { useContext, useEffect, useState } from "react";
import BootstrapTable from "react-bootstrap-table-next";
import Button from "../components/Button";
import Card from "../components/Card";
import { transactionContext } from "../hooks/transactions/transactionContext";
import Table from "../components/Table";

function Transactions() {
  const {transactionsState, getAllTransactions} = useContext(transactionContext);
  const {transactions} = transactionsState;

  const columns = [
    { dataField: "id", text: "ID" },
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

          <Table data={transactions} columns={columns}/>
        </div>
      </Card>
    </>
  );
}

export default Transactions;
