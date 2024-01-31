import React from 'react';
import SearchBar from '../components/searchBar';
import './privatePage.css';
import { useState } from 'react';
import searchService from '../services/searchService.js'

export const PrivatePage = () => {
    const [data, setData] = useState([]);

    const handleSearch = (query) => {
        const json = searchService.findUsers(query);
        setData(json);
    }

    return (
        <div>
            <div className='container'>
                <SearchBar searchButtonClicked={handleSearch}/>
            </div>
           <div>
            {data.id}
            {data.name}
           </div>
        </div>
    );
};
