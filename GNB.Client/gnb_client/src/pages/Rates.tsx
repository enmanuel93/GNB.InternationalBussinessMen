import React, { useState, useEffect } from "react";
import Button from "../components/Button";
import Card from "../components/Card";
import { axiosConnection } from "../config/axiosConnection";
import * as ReactBootStrap from "react-bootstrap";
import BootstrapTable from "react-bootstrap-table-next";
import paginationFactory from "react-bootstrap-table2-paginator";
import Table from "../components/Table";

function Rates() {
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
            <Button type="button">Load Rates</Button>
          </div>

          <Table data={[]} columns={columns}/>
        </div>
      </Card>
    </>
  );
}

export default Rates;
