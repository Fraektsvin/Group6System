package com.example.applicationtier.Models;

import org.springframework.stereotype.Component;

import java.util.Objects;

public class Request {
    private String header;
    private Object obj;

    public Request(){

    }

    public Request(String header, Object obj) {
        this.header = header;
        this.obj = obj;
    }


    public String getHeader() {
        return header;
    }

    public void setHeader(String header) {
        this.header = header;
    }

    public Object getObj() {
        return obj;
    }

    public void setObj(Object obj) {
        this.obj = obj;
    }

    @Override
    public String toString() {
        return header + " " + obj;
    }

}
