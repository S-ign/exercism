package lsproduct

import (
	"fmt"
	"strconv"
)

// LargestSeriesProduct calculates the product of series of integers which is
// converted from string input.
func LargestSeriesProduct(digits string, span int) (int64, error) {
	if span > len(digits) {
		return 0, fmt.Errorf("span must be smaller than string length")
	} 
	if span < 0 {
		return 0, fmt.Errorf("span must be greater than one")
	} 

	var digits_slice []int64
	var largest_number int64
	var err error

	// convert the string of digits into a slice of int64
	for _, n := range digits {
		nn, err := strconv.Atoi(string(n))
		if err != nil {
			return 0, err
		}
		digits_slice = append(digits_slice, int64(nn))
	}

	// create span copy
	sc := span
	
	// loop slice accounting for the size of the span so we don't go out of bound
	for i := 0; i < len(digits_slice)-(span-1); i++ {

		// create a sub slice containing the span of integers
		s := digits_slice[i:sc]
		sc++


		// loop through sub slice to get product
		var product int64 = 1
		for _, p := range s {
			product *= int64(p)
		}


		// if the current product is larger than the current largest number, update it
		if product > largest_number {
			largest_number = product
		}
	}

	return largest_number, err
}
