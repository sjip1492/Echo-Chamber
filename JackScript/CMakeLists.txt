cmake_minimum_required(VERSION 3.16)
project(JackScript C)

set(CMAKE_C_STANDARD 99)

add_custom_target(JackScript COMMAND make -C ${JackScript_SOURCE_DIR}
        CLION_EXE_DIR=${PROJECT_BINARY_DIR})
