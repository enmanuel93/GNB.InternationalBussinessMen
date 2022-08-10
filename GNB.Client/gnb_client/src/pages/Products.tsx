import React, { useState, useEffect, useContext } from "react";
import { FaSearch } from "react-icons/fa";
import Button from "../components/Button";
import Card from "../components/Card";
import CustomInput from "../components/CustomInput";
import Table from "../components/Table";

import { ProductContext } from "../hooks/ProductContext";

interface productProps {
  id: string;
}

function Products() {
  const [uskId, setUskId] = useState<productProps>({ id: "" });
  const { productsState, getAllProducts } = useContext(ProductContext);
  const {
    transactions, totalAmount ,
  } = productsState;

  const columns = [
    { dataField: "id", text: "ID" },
    { dataField: "sku", text: "Sku" },
    { dataField: "currency", text: "Currency" },
    { dataField: "amount", text: "Amount" },
  ];

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>): void => {
    const { name, value } = e.target;
    setUskId({
      ...uskId,
      [name]: value,
    });
  };

  useEffect(() => {
    if(productsState.transactions.length)
      console.log(productsState);
  }, [productsState])

  return (
    <>
      <div className="title">Products</div>
      <Card cardTitle="List of Products">
        <div>
          <div className="button-container">
            <div className="input-container">
              <CustomInput
                name="id"
                onChange={handleChange}
                className="col-md-7"
                placeHolder="Product Id"
              />
              <button
                onClick={() => getAllProducts(uskId.id)}
                className="btn btn-primary"
                style={{ marginLeft: 5 }}
              >
                <FaSearch />
              </button>
            </div>
          </div>

          <Table data={transactions} columns={columns} />
        </div>
      </Card>
    </>
  );
}

export default Products;
