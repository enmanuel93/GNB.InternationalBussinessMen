import React, { useEffect, useState } from "react";
import BootstrapTable from "react-bootstrap-table-next";
import Button from "../components/Button";
import Card from "../components/Card";
import { axiosConnection } from "../config/axiosConnection";
import paginationFactory from "react-bootstrap-table2-paginator";
import Table from "../components/Table";

function Transactions() {
  const [players, setPlayers] = useState([]);
  const [loading, setLoading] = useState(false);

  const getPlayerDate = async () => {
    try {
      const data = await axiosConnection.get(
        "https://nba-players.herokuapp.com/players-stats"
      );
      setPlayers(data.data);
    } catch (error) {
      console.log(error);
    }
  };

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
            <Button type="button">Load Transactions</Button>
          </div>

          <Table data={[]} columns={columns}/>
        </div>
      </Card>
    </>
  );
}

export default Transactions;
