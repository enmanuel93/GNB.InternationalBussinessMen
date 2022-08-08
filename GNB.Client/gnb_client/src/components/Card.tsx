import React, { ReactElement } from "react";

export default function Card(prop: cardProps) {
  return (
    <>
      <div className="container">
        <div
          className="card shadow p-3 mb-5 bg-white rounded"
          style={{ width: "18rem" }}
        >
          <div className="card-body">
            <h5 className="card-title">Special title treatment</h5>
            <p className="card-text">              
              {prop.children}
            </p>
          </div>
        </div>
      </div>
    </>
  );
}

interface cardProps {
    children: ReactElement
}