import DataItemModel from "../models/DataItemModel";
import axios from 'axios'
import PagedResponse from "../models/PagedResponse";

const ROOT_URL = process.env.REACT_APP_API_ROOT || "http://localhost:5243/api";

const PAGE_SIZE = 30;

export const getCountries = async function() : Promise<DataItemModel[]> {
    const response = await axios.get<DataItemModel[]>(
        `${ROOT_URL}/country`
    );
    
    return response.data;
}

export const getCities = async function(countryId: string, search: string | null, startIndex: number | null) : Promise<PagedResponse> {
    const response = await axios.get<PagedResponse>(
        `${ROOT_URL}/city`,
        {
            params: {
                countryId: countryId,
                search: search,
                start: startIndex,
                pageSize: PAGE_SIZE
            }
        });

    return response.data;
}

