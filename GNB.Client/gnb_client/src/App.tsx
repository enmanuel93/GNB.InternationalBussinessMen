import "./App.css";
import React, { useEffect, useState } from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Sidebar from "./components/Sidebar";
import Home from "./pages/Home";
import Products from "./pages/Products";
import Transactions from "./pages/Transactions";
import Rates from "./pages/Rates";
import RateState from "./hooks/rates/rateState";
import TransactionState from "./hooks/transactions/transactionState";
import ProductState from "./hooks/productState";

function App() {
  return (
    <>
      <ProductState>
        <TransactionState>
          <RateState>
            <Router>
              <Sidebar>
                <Routes>
                  <Route path="/" element={<Home />} />
                  <Route path="/products" element={<Products />} />
                  <Route path="/rates" element={<Rates />} />
                  <Route path="/transactions" element={<Transactions />} />
                </Routes>
              </Sidebar>
            </Router>
          </RateState>
        </TransactionState>
      </ProductState>
    </>
  );
}

export default App;
