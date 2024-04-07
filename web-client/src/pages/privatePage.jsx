import React from 'react';
import SearchBar from '../components/searchBar';
import './privatePage.css';
import searchService from '../services/searchService.js'
import Table from '../components/table';

export function PrivatePage() {
    const [data, setData] = React.useState([]);

    const handleSearch = async (query) => {
        let response = await searchService
        .findUsers(query)
        .then((response) => response);

        setData(response.data);
    }

    return (
        <div>
            <div className='container'>
                <SearchBar searchButtonClicked={handleSearch}/>
            </div>
            <div className='container'>
                <Table data={data}/>
            </div>
        </div>
    );
};
