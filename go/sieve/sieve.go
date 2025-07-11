package sieve

type primer interface {
	Valid() bool
}

type prime int

func (p prime) Valid() bool {
	var c int
	for i := 1; i <= int(p); i++ {
		if int(p)%i == 0 {
			c++
		}
		if c > 2 {
			return false
		}
	}
	return true
}

func Sieve(limit int) []int {
	var i prime = 2
	primes := []int{}
	for i = 2; int(i) <= limit; i++ {
		if i.Valid() {
			primes = append(primes, int(i))
		}
	}
	return primes
}

func NewPrime(n int) prime {
	var i prime = prime(n)
	return i
}
