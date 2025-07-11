package airportrobot

import "fmt"

type Greeter interface {
	SayHello(name string) string
}

type Italian struct {} 

func (i Italian) SayHello(name string) string {
	return fmt.Sprintf("I can speak Italian: Ciao %v!", name)
}

type Portuguese struct {}

func (i Portuguese) SayHello(name string) string {
	return fmt.Sprintf("I can speak Portuguese: Olá %v!", name)
}

func SayHello(name string, greater Greeter) string {
	return greater.SayHello(name)
} 
