const formToJSON = elements => [].reduce.call(elements, (data, element) => {
    data[element.name] = element.value;
    return data;
}, {});


const readURL = (input, url_target, display_target) => {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#' + display_target)
                .attr('src', e.target.result)
        };

        reader.readAsDataURL(input.files[0]);

        //upload to the server
        const url = `${ROOT_URL}${IMAGE_UPLOAD}`;
        const formdata = new FormData();
        formdata.append("files", input.files[0]);

        fetch(url, {
            method: 'POST',
            body: formdata,
            redirect: 'follow'
        })
            .then(response => response.json())
            .then(result => { $(`#${url_target}`).val(result.imageURL) })
            .catch(error => console.log('error', error))

    }
}