import React from 'react';
import SearchBar from '../components/searchBar';
import searchService from '../services/searchService.js';
import './privatePage.css';
import { useState } from 'react';
import Table from '../components/table';

export const PrivatePage = () => {
    const [data, setData] = useState();

    const handleSearch = (query) => {
        const json = searchService.findUsers(query);
        setData(json);
    }

    return (
        <div>
            <div className='container'>
                <SearchBar searchButtonClicked={handleSearch}/>
            </div>
            <Table data={data}/>
        </div>
    );
};
