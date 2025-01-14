async function fetchData(url, method = 'GET', data = null, headers = {}) {
    try {
        const options = {
            method,
            headers: {
                'Content-Type': 'application/json',
                ...headers,
            },
        };

        if (data && ['POST', 'PUT', 'PATCH'].includes(method.toUpperCase())) {
            options.body = JSON.stringify(data);
        }

        const response = await fetch(url, options);

        if (!response.ok) {
            throw new Error(`HTTP Error: ${response.status}`);
        }

        if (method === 'POST' || method === 'DELETE' || method === 'PUT') return;

        const result = await response.json();
        return result;
    }
    catch (error) {
        console.error(`Błąd podczas zapytania: ${error.message}`);
        throw error;
    }
}