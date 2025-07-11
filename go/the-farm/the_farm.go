package thefarm

import (
	"errors"
	"fmt"
)

type InvalidCowsError struct {
	cows    int
	message string
}

func (i *InvalidCowsError) Error() string {
	switch {
	case i.cows < 0:
		i.message = "there are no negative cows"
	case i.cows == 0:
		i.message = "no cows don't need food"
	default:
		i.message = "no soup for you"
	}
	return fmt.Sprintf("%d cows are invalid: %v", i.cows, i.message)
}

// TODO: define the 'DivideFood' function
func DivideFood(fc FodderCalculator, cows int) (float64, error) {
	amount, err := fc.FodderAmount(cows)
	if err != nil {
		return 0, err
	}
	ff, err := fc.FatteningFactor()
	if err != nil {
		return 0, err
	}
	return float64(amount/float64(cows)) * ff, nil
}

// TODO: define the 'ValidateInputAndDivideFood' function
func ValidateInputAndDivideFood(fc FodderCalculator, cows int) (float64, error) {
	if cows > 0 {
		return DivideFood(fc, cows)
	}
	return 0, errors.New("invalid number of cows")
}

// TODO: define the 'ValidateNumberOfCows' function
func ValidateNumberOfCows(cows int) error {
	if cows <= 0 {
		return &InvalidCowsError{cows: cows}
	}
	return nil
}

// Your first steps could be to read through the tasks, and create
// these functions with their correct parameter lists and return types.
// The function body only needs to contain `panic("")`.
//
// This will make the tests compile, but they will fail.
// You can then implement the function logic one by one and see
// an increasing number of tests passing as you implement more
// functionality.
