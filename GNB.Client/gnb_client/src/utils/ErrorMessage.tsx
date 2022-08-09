import React from 'react';

export default function ErrorMessage(prop: ErrorMsgProps) {
    return (
        <div>{prop.message}</div>
    );
}

interface ErrorMsgProps{
   message: string;
} 
