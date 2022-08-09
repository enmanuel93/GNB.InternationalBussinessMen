import React from 'react';
import * as ReactBootStrap from "react-bootstrap";
import BootstrapTable from "react-bootstrap-table-next";
import paginationFactory from "react-bootstrap-table2-paginator";

export default function Table(props: tablePros) {
    return (
        <BootstrapTable
            bootstrap4
            keyField="id"
            data={props.data}
            columns={props.columns}
            pagination={paginationFactory(
              { sizePerPage: 5, custom: false})
            }
        />
    );
}

interface tablePros {
    data: any;
    columns: any;
}