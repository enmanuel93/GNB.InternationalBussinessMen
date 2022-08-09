import React, { useState, useEffect, useContext } from "react";
import { FaSearch } from "react-icons/fa";
import Button from "../components/Button";
import Card from "../components/Card";
import CustomInput from "../components/CustomInput";
import Table from "../components/Table";

import { ProductContext } from "../hooks/ProductContext";

function Products() {
  const {productSt, getAllProducts} = useContext(ProductContext);

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
              <button onClick={() => getAllProducts()} className="btn btn-primary" style={{marginLeft: 5}}>
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
