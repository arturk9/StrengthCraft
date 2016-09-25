(function() {
    var $regulationsCheckbox = $('#regulations-checkbox'),
        $regulationsSubmitBtn = $('#submit-regulations-btn');

    function enableSubmitButton() {
        $regulationsSubmitBtn.attr('disabled', !this.checked);
    }

    $regulationsCheckbox.on('change', enableSubmitButton);

})();