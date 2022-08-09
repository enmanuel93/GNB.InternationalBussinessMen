import React, { useEffect, useState } from "react";
import Button from "../components/Button";
import Card from "../components/Card";
import { axiosConnection } from "../config/axiosConnection";
import Table from "../components/Table";
import { FaSearch } from "react-icons/fa";
import CustomInput from "../components/CustomInput";

function Products() {
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
      <div className="title">Products</div>
      <Card cardTitle="List of Products">
        <div>
          <div className="button-container">
            <div className="input-container">
              <CustomInput className="col-md-7" placeHolder="Product Id" />
              <button className="btn btn-primary" style={{marginLeft: 5}}>
                <FaSearch />
              </button>
            </div>
          </div>

          <Table data={[]} columns={columns} />
        </div>
      </Card>
    </>
  );
}

export default Products;
