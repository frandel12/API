// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const lists__pokemons = document.getElementById('list_pokemons')
const buttons = document.getElementById('buttons')
let urlPokemon = ' https://pokeapi.co/api/v2/pokemon?limit=151'
let templateHtml;
console.log('⏮⏩')

const GetPokemons = async (url) => {
    try {
        const response = await fetch(url)
        const results = await response.json();
        console.log(results)
        DataPokemons(results.results)

    } catch (error) {
        console.log(error)
    }
}
GetPokemons(urlPokemon)

const DataPokemons = async (data) => {
    list_pokemons.innerHTML = '';
    try {
        for (let index of data) {

            const resp = await fetch(index.url)
            const resul = await resp.json();
            console.log(resul)
            templateHtml = `
            <div class="pokemon_img">
            <img src=${resul.sprites.other.dream_world.front_default} alt=${resul.name}/>
            <p>#${resul.id}</p>
            <p>${resul.name}</p>
                <div class="types">
                    ${resul.types
                    .map((type) => {
                        return `<p>${type.type.name}</p>`;
                    })
                    .join("")}
                </div>
            </div>
            `
            list_pokemons.innerHTML += templateHtml
        }

    } catch (error) {
        console.log(error)
    }
}

buttons.addEventListener('click', (e) => {
    if (e.target.classList.contains('btn')) {
        let value = e.target.dataset.url
        console.log(value)
        GetPokemons(value)
    }
})